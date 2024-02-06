using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardResource : MonoBehaviour
{
    public WeatherList.weather CurrentWeather;

    public WeatherList.weather needWeather;

    public CreateCard CardMaker;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool weatherCrafting(BehaviorStack inputBehavior) //�ൿ ������ �Է¹޾� ���� ����, ������ ������ ��ǥ ������ ���� �� Ȯ��
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
}