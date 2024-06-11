using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    public float PlayerHP = 100f;
    public float PlayerExp = 1f;
    public int Coin = 0;
    public  static int coinCount = 0;

    private GameObject Player;


    public static int monsterCount;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance);
    }

    void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

   public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        Player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return Player;
    }

    public static void AddCoin(int amount)
    {
        coinCount += amount;
    }

}
