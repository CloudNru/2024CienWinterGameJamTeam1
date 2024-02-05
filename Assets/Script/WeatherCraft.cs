using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherCraft
{
    public static WeatherList.weather CraftingWeather(WeatherList.weather nowWeather, BehaviorStack behavior)
    {
        return WeatherList.weather.Sunny;
    }
}
