using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;

    public Transform cameraTransform; // 카메라의 Transform 컴포넌트
    public Transform target; // 카메라가 따라갈 대상
    public float shakeDuration = 0.1f; // 흔들림 지속 시간
    public float shakeMagnitude = 0.3f; // 흔들림 강도

    private Vector3 originalPosition; // 원래 카메라 위치
    private float elapsed = 0f; // 흔들림 경과 시간

    private void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void Start()
    {
        // 카메라 원래 위치 초기화
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
            // 카메라를 타겟을 향해 부드럽게 따라가도록 설정
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        }

        if (elapsed < shakeDuration)
        {
            // 흔들림 효과 계산
            //float x = Random.Range(-1f, 1f) * shakeMagnitude;
            //float y = Random.Range(-1f, 1f) * shakeMagnitude;

            // 카메라 위치 변경
            //cameraTransform.localPosition = originalPosition + new Vector3(x, y, 0f);

            // 경과 시간 갱신
            //elapsed += Time.deltaTime;
        }
        else
        {
            // 흔들림이 끝난 후 카메라 위치 초기화
            //cameraTransform.localPosition = originalPosition;
            //elapsed = 0f;
        }
    }

    // 몬스터 공격을 받았을 때 호출되는 메서드
    public void ShakeCameraOnAttack()
    {
        //elapsed = 0f; // 흔들림 효과 시작
    }
}
