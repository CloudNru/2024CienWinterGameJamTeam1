using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public void GameStart()
    {
        SceneManager.LoadScene("MakingUIScene");
    }
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
    public void ClosePanel()
    {
        howToPlayPanel.SetActive(false);
    }


}
