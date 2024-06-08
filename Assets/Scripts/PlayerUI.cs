using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;
    public Text CoinText;

    public Slider HpSlider;
    private GameObject player;
    public GameObject spawnPos;
    public static int scoreValue;

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
        CoinText = GetComponent<Text>();
    }


    void Update()
    {
        display();
        CoinText.text = ": " + scoreValue;
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

            PlayerUI.scoreValue += 1;
        }
    }
}



