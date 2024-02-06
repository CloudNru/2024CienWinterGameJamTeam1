using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardResource : MonoBehaviour
{
    [SerializeField]
    WeatherList.weather CurrentWeather;

    [SerializeField]
    WeatherList.weather needWeather;

    [SerializeField]
    Sprite successSprite;

    [SerializeField]
    CreateCard CardMaker;

    [SerializeField]
    Image image;

    [SerializeField] 
    Image icon;

    [SerializeField] 
    Vector3 origin;

    RectTransform rect;

    [SerializeField]
    bool isActive = true;

    [SerializeField]
    float waitingTime = 0.5f;

    [SerializeField]
    float movingTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        rect = this.gameObject.GetComponent<RectTransform>();
        origin = rect.anchoredPosition;
        Invoke("ChangeWeather", 1f);
        Invoke("setTrue", 1f);
    }

    void setTrue()
    {
        isActive = true;
    }

    public void weatherCrafting(BehaviorStack inputBehavior) //행동 정보를 입력받아 날씨 조합, 조합한 날씨가 목표 날씨와 같은 지 확인
    {
        if (isActive)
        {
            WeatherList.weather CraftedWeather = WeatherCraft.CraftingWeather(CurrentWeather, inputBehavior);
            if (CraftedWeather == needWeather)
            {
                GameManager.getInstance().AddScore(1);
                Sucess();
            }
            else
            {
                GameManager.getInstance().SubtractScore(1);
                GameManager.getInstance().LoseLife(1);
                Fail();
            }
        }
    }

    void Sucess()
    {
        isActive = false;
        image.sprite = successSprite;
        Invoke("goCard", waitingTime);
    }

    void Fail()
    {
        isActive = false;
        Invoke("goCard", waitingTime);
    }

    void goCard()
    {
        rect.DOAnchorPos(origin - new Vector3(0,Camera.main.scaledPixelHeight, 0), movingTime);
        Invoke("ChangeAndBack", movingTime);
    }

    void ChangeWeather()
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

        int i = Random.Range(0, 3);
        image.sprite = CardMaker.getGoalImage(needWeather, i);
        this.successSprite = CardMaker.getGoalSuccessImage(needWeather,i);
    }

    void ChangeAndBack()
    {
        ChangeWeather();
        Invoke("endSet", movingTime);
    }

    void endSet()
    {
        rect.DOAnchorPos(origin, movingTime);
        isActive = true;
    }
}