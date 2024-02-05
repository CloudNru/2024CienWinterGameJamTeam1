using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public GameObject howToPlayPanel;
    private bool isPanelActivated = false;

    public Image sun;
    public Sprite[] sunSprites;
    public Button sunButton;
    int index;
    int sunCount = 0;

    private void Start()
    {
        index = 0;
        sun.sprite = sunSprites[index];
        InvokeRepeating("ImagesAnimation", 1f,1f);
    }

    public void GameStart()
    {
        if (!isPanelActivated) { 
            SceneManager.LoadScene("MakingUIScene");
        }
    }
    public void ShowHowToPlay()
    {
        if (!isPanelActivated)
        {
            howToPlayPanel.SetActive(true);
            isPanelActivated = true;
            sunButton.interactable = false;
        }
    }
    public void ExitGame()
    {
        if (!isPanelActivated)
        {
            Debug.Log("Exit!");
            Application.Quit();
        }
    }
    public void ClosePanel()
    {
        if (isPanelActivated) { 
            howToPlayPanel.SetActive(false);
            isPanelActivated= false;
            sunButton.interactable = true;
        }
    }
    void ImagesAnimation()
    {
        if (index == 0)
        {
            index = 1;
            sun.sprite = sunSprites[index];
        }
        else if(index == 1)
        {
            index = 0;
            sun.sprite = sunSprites[index];
        }

    }
    public void PraiseTheSun()
    {
        if(sunCount < 10)
        {
            sunCount++;
        }
        else if(sunCount == 10)
        {
            Debug.Log("EasterEgg!");
        }
    }
}
