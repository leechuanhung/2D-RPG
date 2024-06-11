using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;

    public Transform cameraTransform; // ī�޶��� Transform ������Ʈ
    public Transform target; // ī�޶� ���� ���
    public float shakeDuration = 0.1f; // ��鸲 ���� �ð�
    public float shakeMagnitude = 0.3f; // ��鸲 ����

    private Vector3 originalPosition; // ���� ī�޶� ��ġ
    private float elapsed = 0f; // ��鸲 ��� �ð�

    private void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void Start()
    {
        // ī�޶� ���� ��ġ �ʱ�ȭ
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 2.5f, transform.position.z);
        }

        if (target != null)
        {
            // ī�޶� Ÿ���� ���� �ε巴�� ���󰡵��� ����
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        }

        if (elapsed < shakeDuration)
        {
            // ��鸲 ȿ�� ���
            //float x = Random.Range(-1f, 1f) * shakeMagnitude;
            //float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // ī�޶� ��ġ ����
            //cameraTransform.localPosition = originalPosition + new Vector3(x, y, 0f);

            // ��� �ð� ����
            //elapsed += Time.deltaTime;
        }
        else
        {
            // ��鸲�� ���� �� ī�޶� ��ġ �ʱ�ȭ
            //cameraTransform.localPosition = originalPosition;
            //elapsed = 0f;
        }
    }

    // ���� ������ �޾��� �� ȣ��Ǵ� �޼���
    public void ShakeCameraOnAttack()
    {
        //elapsed = 0f; // ��鸲 ȿ�� ����
    }
}
