
using UnityEngine;

public class Item : MonoBehaviour
{
    public int coinAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                GameManager.AddCoin(coinAmount);
                Debug.Log("Player Coin : " + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player coin : " +  GameManager.Instance.PlayerHP);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "Speed")
            {
                GameManager.Instance.Player.GetComponent<Character>().Speed += 5;
                Debug.Log("Player Speed: " + GameManager.Instance.Player.GetComponent<Character>().Speed);
                Destroy(gameObject);
            }
            else if( gameObject.tag == "Damage")
            {
                GameManager.Instance.Player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage += 5;
                Debug.Log("Player Attack Damage: " + GameManager.Instance.Player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage);
                Destroy(gameObject);
            }
        }
    }
}

