using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;
    public GameObject BackPack_UI;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemDatas;

    private int defItemUsingCount = 0;
    private int speedItemUsingCount = 0;
    private int powerItemUsingCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventoryItemDatas = new InventoryItemData[ItemImages.Length];
    }


    void Update()
    {
        BackPackUIOn();
        CoinText.text = $"Coin: {GameManager.Instance.PlayerStat.Coin:N0}";
    }

    private void BackPackUIOn()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }
    }

    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < ItemImages.Length; i++)
        {
            if (ItemImages[i].sprite == null)
            {
                ItemImages[i].sprite = item.itemImage;
                InventoryItemDatas[i] = item;
                return true;
            }
        }
        return false;
    }

    public void ItemUse()
    {
        int siblingIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        InventoryItemData inventoryItem = InventoryItemDatas[siblingIndex];
        if (inventoryItem.itemID == "HP")
        {
            GameManager.Instance.PlayerStat.HP += 10f;
            GameManager.Instance.PlayerStat.HP = Mathf.Min(GameManager.Instance.PlayerStat.HP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("체력이 10 회복 되었습니다.");
        }
        else if(inventoryItem.itemID == "MP")
        {
            GameManager.Instance.PlayerStat.MP += 10f;
            GameManager.Instance.PlayerStat.MP = Mathf.Min(GameManager.Instance.PlayerStat.MP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("마나가 10 회복 되었습니다.");
        }
        else if(inventoryItem.itemID == "HP_Power")
        {
            GameManager.Instance.PlayerStat.HP += 100f;
            PopupMsgManager.Instance.ShowPopupMessage("체력 전체가 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "MP_Power")
        {
            GameManager.Instance.PlayerStat.MP += 100f;
            PopupMsgManager.Instance.ShowPopupMessage("마나 전체가 회복 되었습니다.");
        }
        else if(inventoryItem.itemID == "DT")
        {
            StartCoroutine(DefItem());
        }
        else if(inventoryItem.itemID == "SP")
        {
            StartCoroutine(SpeedItem());
        }
        else if(inventoryItem.itemID == "AT")
        {
            StartCoroutine(PowerItem());
        }
        else if(inventoryItem.itemID == "DD")
        {
            //보스전 나올 때 구현
        }
        else
        {
            Debug.LogError($"존재하지 않은 itemID[{inventoryItem.itemID}]");
            return;
        }

        InventoryItemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    }

    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.PlayerStat.Def *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. playerDef : " + GameManager.Instance.PlayerStat.Def);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.PlayerStat.Def /= 2;
        if(defItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("2. PlayerDef : " + GameManager.Instance.PlayerStat.Def);
        }
    }

    IEnumerator SpeedItem()
    {
        speedItemUsingCount++;
        GameManager.Instance.Character.Speed *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color= Color.red;
        Debug.Log("1. Speed : " + GameManager.Instance.Character.Speed);
        yield return new WaitForSeconds(10f);

        speedItemUsingCount--;
        GameManager.Instance.Character.Speed /= 2;
        if(speedItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent <SpriteRenderer>().color = Color.white;
        Debug.Log("2. Speed : " + GameManager.Instance.Character.Speed);
    }

    IEnumerator PowerItem()
    {
        powerItemUsingCount++;
        GameManager.Instance.CharacterAttack.AttackDamage *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
        yield return new WaitForSeconds(10f);

        powerItemUsingCount--;
        GameManager.Instance.CharacterAttack.AttackDamage /= 2;
        if (powerItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("1. Charcter Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
    }
}
