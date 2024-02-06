using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardResource : MonoBehaviour
{
    public WeatherList.weather CurrentWeather;

    public WeatherList.weather needWeather;

    public CreateCard CardMaker;

    public Image image;
    public Image icon; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeWeather", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool weatherCrafting(BehaviorStack inputBehavior) //행동 정보를 입력받아 날씨 조합, 조합한 날씨가 목표 날씨와 같은 지 확인
    {
        WeatherList.weather CraftedWeather = WeatherCraft.CraftingWeather(CurrentWeather, inputBehavior);
        if (CraftedWeather == needWeather)
        {
            GameManager.getInstance().AddScore(1);
            CardMaker.changeCard(this);

            return true;
        }
        GameManager.getInstance().SubtractScore(1);
        GameManager.getInstance().LoseLife(1);
        return false;
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
}