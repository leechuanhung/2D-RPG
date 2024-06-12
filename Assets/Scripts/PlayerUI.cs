using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;
    
    public Text MCText;
    public Text coinCountText;

    public Slider HpSlider;
    private GameObject player;
    public GameObject spawnPos;
    public static int coinAmount;


    public Text timerText; // 타이머를 표시할 Text 컴포넌트
    private float elapsedTime; // 경과 시간

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
        
        if (timerText == null)
        {
            return;
        }

        elapsedTime = 0f;
        UpdateCoinCountText();
    }


    void Update()
    {
        display();
        coinCountText.text = ": " + coinAmount.ToString();
        int count = GameManager.monsterCount;
        MCText.text = ": " + count.ToString();
        if (timerText == null)
        {
            Debug.LogError("Timer Text is not assigned!");
            return;
        }

        elapsedTime += Time.deltaTime; // 경과 시간 업데이트

        // 경과 시간을 분과 초로 변환
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // 시간 포맷 설정
        if (minutes > 0)
        {
            timerText.text = string.Format("{0:D1}분 {1:D2}초", minutes, seconds);
        }
        else
        {
            timerText.text = string.Format("{0:D1}초", seconds);
        }

        //Debug.Log("Time Updated: " + timerText.text); // 디버그 메시지 추가
    }


    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            //PlayerUI.coinAmount += 1;
        }
    }

    public void UpdateCoinCountText()
    {
        coinCountText.text = ": " + GameManager.coinCount.ToString();
    }

}



