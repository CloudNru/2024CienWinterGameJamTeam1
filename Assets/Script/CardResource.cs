using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardResource : MonoBehaviour
{
    public WeatherList.weather CurrentWeather;

    public WeatherList.weather needWeather;

    public CreateCard CardMaker;

    public Image image;
    public Image icon;

    public Vector3 origin;

    RectTransform rect;

    [SerializeField]
    bool isActive = true;

    [SerializeField]
    float movingTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        rect = this.gameObject.GetComponent<RectTransform>();
        origin = rect.anchoredPosition;
        Invoke("ChangeWeather", 1f);
    }

    public void weatherCrafting(BehaviorStack inputBehavior) //행동 정보를 입력받아 날씨 조합, 조합한 날씨가 목표 날씨와 같은 지 확인
    {
        if (isActive)
        {
            WeatherList.weather CraftedWeather = WeatherCraft.CraftingWeather(CurrentWeather, inputBehavior);
            if (CraftedWeather == needWeather)
            {
                GameManager.getInstance().AddScore(1);
                goCard();
            }
            else
            {
                GameManager.getInstance().SubtractScore(1);
                GameManager.getInstance().LoseLife(1);
                goCard();
            }
        }
    }

    public void goCard()
    {
        isActive = false;
        rect.DOAnchorPos(origin - new Vector3(0,Camera.main.scaledPixelHeight, 0), movingTime);
        Invoke("ChangeAndBack", movingTime);
    }

    public void ChangeWeather()
    {
        CurrentWeather = (WeatherList.weather)Random.Range(1, 7);
        icon.sprite= CardMaker.getCurrentIcon(CurrentWeather);

        needWeather = (WeatherList.weather)Random.Range(1, 7);
        if (CurrentWeather == needWeather)
        {
            while(CurrentWeather == needWeather)
            {
                needWeather = (WeatherList.weather)Random.Range(1, 7);
            }
        }
        image.sprite = CardMaker.getGoalImage(needWeather);
    }

    public void ChangeAndBack()
    {
        ChangeWeather();
        Invoke("endSet", movingTime);
    }

    public void endSet()
    {
        rect.DOAnchorPos(origin, movingTime);
        isActive = true;
    }
}