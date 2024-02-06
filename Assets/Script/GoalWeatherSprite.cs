using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoalWeatherSprite", menuName = "Scriptable Object/GoalWeatherSprite", order = int.MaxValue)]
public class GoalWeatherSprite : ScriptableObject
{
    [SerializeField]
    public WeatherList.weather weather;

    [SerializeField]
    public Sprite image1;

    [SerializeField]
    public Sprite image2;

    [SerializeField]
    public Sprite image3;
}
