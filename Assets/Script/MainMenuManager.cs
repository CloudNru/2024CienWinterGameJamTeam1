using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class MainMenuManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    private bool isPanelActivated = false;

    public Image sun;
    public Sprite[] sunSprites;
    public Button sunButton;
    int index;
    int sunCount = 0;

    [SerializeField]
    Image solar;

    bool isSolarMoving = false;

    [SerializeField]
    float repeatTime = 0.75f;

    [SerializeField]
    float solarTime = 0.75f;

    private void Start()
    {
        index = 0;
        sun.sprite = sunSprites[index];
        InvokeRepeating("ImagesAnimation", repeatTime, repeatTime);
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
            if (!isSolarMoving)
            {
                solar.gameObject.SetActive(true);
                float h = GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y;
                RectTransform rect = solar.gameObject.GetComponent<RectTransform>();

                rect.anchoredPosition = new Vector2(0, -h);
                rect.DOAnchorPos(new Vector2(0, h), solarTime);
                isSolarMoving = true;
                Invoke("ResetSolar", 1.5f);
            }
        }
    }

    void ResetSolar()
    {
        solar.gameObject.SetActive(false);
        isSolarMoving = false;
        sunCount = 0;
    }
}
