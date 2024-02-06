using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftText : MonoBehaviour
{
    [SerializeField]
    BehaviorStack stack;

    [SerializeField]
    WeatherList.weather weather;

    [SerializeField]
    Text text;

    public void doMaking()
    {
        text.text = WeatherList.weatherString[(int)WeatherCraft.CraftingWeather(weather, stack)];
    }

    public void changeWeather(WeatherList.weather weather)
    {
        this.weather = weather;
    }
}
