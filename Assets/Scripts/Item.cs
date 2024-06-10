using System.Collections;
using System.Collections.Generic;
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
        }
    }
}

