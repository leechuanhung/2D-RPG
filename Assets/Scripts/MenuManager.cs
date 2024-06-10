using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToStartScene()
    {
        SceneManager.LoadScene("StarScene");
    }

    public void GoToSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
