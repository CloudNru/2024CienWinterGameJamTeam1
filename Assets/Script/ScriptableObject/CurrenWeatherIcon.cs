using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrenWeatherIcon", menuName = "Scriptable Object/CurrenWeatherIcon", order = int.MaxValue)]
public class CurrenWeatherIcon : ScriptableObject
{
    [SerializeField]
    public WeatherList.weather weather;

    [SerializeField]
    public Sprite icon;
}
