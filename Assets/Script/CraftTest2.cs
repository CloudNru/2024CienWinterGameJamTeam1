using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftTest2 : MonoBehaviour
{
    [SerializeField]
    WeatherList.weather weather;

    [SerializeField]
    CraftText craft;

    [SerializeField]
    Text text;

    public void doIt()
    {
        craft.changeWeather(this.weather);
        text.text = WeatherList.weatherString[(int)weather];
    }

}
