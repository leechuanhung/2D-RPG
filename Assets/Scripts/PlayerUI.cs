using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharacterImg;
    public Text IdText;
    public Text LvText;

    public Slider HpSlider;
    public Slider MpSlider;
    public Slider ExpSlider;
    private GameObject player;
    //public GameObject spawnPos;
    
    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        GameObject spawnPos = GameObject.FindGameObjectWithTag("InitPos");
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }


    void Update()
    {
        display();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerStat.HP;
        MpSlider.value = GameManager.Instance.PlayerStat.MP;
        ExpSlider.value = GameManager.Instance.PlayerStat.Exp;
        LvText.text = "Lv : " + GameManager.Instance.PlayerStat.Lv;
    }

}
