using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoalWeatherSprite", menuName = "Scriptable Object/GoalWeatherSprite", order = int.MaxValue)]
public class GoalWeatherSprite : ScriptableObject
{
    [SerializeField]
    public WeatherList.weather weather;

    [SerializeField]
    public Sprite[] image = new Sprite[3];

    [SerializeField]
    public Sprite[] successImage = new Sprite[3];
}
