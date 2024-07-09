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
        CoinText.text = $"Coin: {GameManager.Instance.Coin:N0}";
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
            GameManager.Instance.PlayerHP += 10f;
            GameManager.Instance.PlayerHP = Mathf.Min(GameManager.Instance.PlayerHP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("ü���� 10 ȸ�� �Ǿ����ϴ�.");
        }
        else if(inventoryItem.itemID == "MP")
        {
            GameManager.Instance.PlayerMP += 10f;
            GameManager.Instance.PlayerMP = Mathf.Min(GameManager.Instance.PlayerMP, 100f);
            PopupMsgManager.Instance.ShowPopupMessage("������ 10 ȸ�� �Ǿ����ϴ�.");
        }
        else if(inventoryItem.itemID == "HP_Power")
        {
            GameManager.Instance.PlayerHP += 100f;
            PopupMsgManager.Instance.ShowPopupMessage("ü�� ��ü�� ȸ�� �Ǿ����ϴ�.");
        }
        else if (inventoryItem.itemID == "MP_Power")
        {
            GameManager.Instance.PlayerMP += 100f;
            PopupMsgManager.Instance.ShowPopupMessage("���� ��ü�� ȸ�� �Ǿ����ϴ�.");
        }
        else if(inventoryItem.itemID == "Def")
        {
            StartCoroutine(DefItem());
        }
        else if(inventoryItem.itemID == "Speed")
        {
            StartCoroutine(SpeedItem());
        }
        else if(inventoryItem.itemID == "Power")
        {
            StartCoroutine(PowerItem());
        }
        else if(inventoryItem.itemID == "Super")
        {
            //������ ���� �� ����
        }
        else
        {
            Debug.LogError($"�������� ���� itemID[{inventoryItem.itemID}]");
            return;
        }

        InventoryItemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    }

    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.PlayerDef *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. playerDef : " + GameManager.Instance.PlayerDef);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.PlayerDef /= 2;
        if(defItemUsingCount == 0)
        {
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("2. PlayerDef : " + GameManager.Instance.PlayerDef);
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

        powerItemUsingCount--;
        GameManager.Instance.CharacterAttack.AttackDamage /= 2;
        if (powerItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("1. Charcter Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
    }
}
