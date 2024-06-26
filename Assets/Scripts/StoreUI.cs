using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image[] ItemImage;
    public Text[] ItemTexts;
    public InventoryItemData[] itemDatas;
    
    void Start()
    {
        for(int i = 0; i < itemDatas.Length; i++)
        {
            ItemImage[i].sprite = itemDatas[i].itemImage;
            ItemTexts[i].text = $"{itemDatas[i].itemName} ({itemDatas[i].itemPrice:N0}P)";
        }
    }

   
    void Update()
    {
        
    }
}
