using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillExplainUI;
    public Image SkillImage;
    public Text SkillText;

    public void ExplainSkillBtn(int number)
    {
        SkillExplainUI.gameObject.SetActive(true);
        SkillImage.sprite = EventSystem.current.
            currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (GameManager.Instance.SelectedPlayer)
        {
            case Define.Player.Warrior:
                if (number == 0) SkillText.text = "전사의 첫 번째 스킬";
                else if (number == 1) SkillText.text = "전사의 두 번째 스킬";
                else if (number == 2) SkillText.text = "전사의 세 번째 스킬";
                break;
            case Define.Player.Archer:
                if(number == 0) SkillText.text = "궁수의 첫 번째 스킬";
                else if (number == 1) SkillText.text = "궁수의 두 번째 스킬";
                else if (number == 2) SkillText.text = "궁수의 세 번째 스킬";
                break;
            case Define.Player.Mage:
                if (number == 0) SkillText.text = "마법사의 첫 번재 스킬";
                else if (number == 1) SkillText.text = "마법사의 두 번째 스킬";
                else if (number == 2) SkillText.text = "마법사의 세 번째 스킬";
                break;
        }
        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        SkillExplainUI.SetActive(false);
    }
}
