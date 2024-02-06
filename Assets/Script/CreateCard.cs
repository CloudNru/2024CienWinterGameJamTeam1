using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCard : MonoBehaviour
{
    [SerializeField]
    public GameObject Card;

    [SerializeField]
    private Image cardImage;

    private WeatherList.weather[] allWeathers = new WeatherList.weather[] {
        WeatherList.weather.Sunny,
        WeatherList.weather.Wind,
        WeatherList.weather.Rain,
        WeatherList.weather.Snow,
        WeatherList.weather.Lightning,
        WeatherList.weather.Fog
        // ... 다른 날씨 값들 추가
    };

    // Start is called before the first frame update
    void Start()
    {
        cardImage = GetComponent<Image>();
        newCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardResource newCard()
    {
        //*
        if (Card != null) // Card가 할당되었는지 확인
        {
            WeatherList.weather randomWeather = (WeatherList.weather)allWeathers[Random.Range(0, allWeathers.Length)];

            GameObject _object = Instantiate(Card);
            CardResource card = _object.GetComponent<CardResource>();

            if (card != null) // CardResource 컴포넌트가 할당되었는지 확인
            {
                card.CurrentWeather = randomWeather;
                //cardImage.sprite =
                randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];
                card.needWeather = randomWeather;

                card.CardMaker = this;

                return card;
            }
            else
            {
                Debug.LogError("CardResource 컴포넌트가 없습니다.");
                return null;
            }
        }
        else
        {
            Debug.LogError("Card이(가) 할당되지 않았습니다.");
            return null;
        }
        //*/
        /*
        WeatherList.weather randomWeather = WeatherList.weather.Rain;

        GameObject _object = Instantiate(Card);
        CardResource card = _object.GetComponent<CardResource>();
        card.CurrentWeather = randomWeather;

        randomWeather = WeatherList.weather.snow;
        card.needWeather = randomWeather;

        card.CardMaker = this;

        return card;//*/
    }

    public CardResource changeCard(CardResource c)
    {
        WeatherList.weather randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];

        c.CurrentWeather = randomWeather;

        randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];
        c.needWeather = randomWeather;

        return c;
        /* WeatherList.weather randomWeather = (WeatherList.weather)Random.Range(0, System.Enum.GetValues(typeof(WeatherList)).Length);

         c.CurrentWeather = randomWeather;

         randomWeather = (WeatherList.weather)Random.Range(0, System.Enum.GetValues(typeof(WeatherList)).Length);
         c.needWeather = randomWeather;

         return c;*/
    }
}
