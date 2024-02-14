using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreateCard : MonoBehaviour
{
    [SerializeField]
    public GameObject Card;

    private WeatherList.weather[] allWeathers = new WeatherList.weather[] {
        WeatherList.weather.Sunny,
        WeatherList.weather.Wind,
        WeatherList.weather.Rain,
        WeatherList.weather.Snow,
        WeatherList.weather.Lightning,
        WeatherList.weather.Fog
        // ... �ٸ� ���� ���� �߰�
    };

    [SerializeField]
    List<GoalWeatherSprite> goalWeathers = new List<GoalWeatherSprite>();

    [SerializeField]
    List<CurrenWeatherIcon> currentWeatherImages = new List<CurrenWeatherIcon>();

    [SerializeField]
    List<RectTransform> cardPositions = new List<RectTransform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(GoalWeatherSprite sprite in Resources.LoadAll<GoalWeatherSprite>("GoalWeatherSprite"))
        {
            goalWeathers.Add(sprite);
        }

        foreach (CurrenWeatherIcon sprite in Resources.LoadAll<CurrenWeatherIcon>("WeatherIcon"))
        {
            currentWeatherImages.Add(sprite);
        }
    }

    private void Awake()
    {
        Invoke("setStart", 1f);
    }

    void setStart()
    {
        foreach (RectTransform rectTransform in cardPositions)
        {
            newCard(rectTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CardResource newCard(RectTransform position)
    {
        if(Card == null)
        {
            return null;
        }

        GameObject _card = Instantiate(Card, position.transform);
        //_card.GetComponent<RectTransform>().anchoredPosition = position.anchoredPosition;
        _card.SetActive(true);
        return _card.GetComponent<CardResource>();
    }

    /*
    public CardResource newCard()
    {
        //*
        if (Card != null) // Card�� �Ҵ�Ǿ����� Ȯ��
        {
            WeatherList.weather randomWeather = (WeatherList.weather)allWeathers[Random.Range(0, allWeathers.Length)];

            GameObject _object = Instantiate(Card, GameObject.Find("Canvas").transform);
            CardResource card = _object.GetComponent<CardResource>();

            if (card != null) // CardResource ������Ʈ�� �Ҵ�Ǿ����� Ȯ��
            {
                card.CurrentWeather = randomWeather;
                int i = Random.Range(0, 3);
                _object.GetComponent<Image>().sprite = goalWeathers.Find(x => x.weather == randomWeather).image[i];
                randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];
                card.needWeather = randomWeather;

                card.CardMaker = this;

                return card;
            }
            else
            {
                Debug.LogError("CardResource ������Ʈ�� �����ϴ�.");
                return null;
            }
        }
        else
        {
            Debug.LogError("Card��(��) �Ҵ���� �ʾҽ��ϴ�.");
            return null;
        }
        
        
        WeatherList.weather randomWeather = WeatherList.weather.Rain;

        GameObject _object = Instantiate(Card);
        CardResource card = _object.GetComponent<CardResource>();
        card.CurrentWeather = randomWeather;

        randomWeather = WeatherList.weather.snow;
        card.needWeather = randomWeather;

        card.CardMaker = this;

        return card;
    }//*/

    public Sprite getCurrentIcon(WeatherList.weather weather)
    {
        return currentWeatherImages.Find(x => x.weather == weather).icon;
    }

    public Sprite getGoalImage(WeatherList.weather weather)
    {
        int i = Random.Range(0, 3);
        return goalWeathers.Find(x => x.weather == weather).image[i];
    }

    public Sprite getGoalImage(WeatherList.weather weather, int index)
    {
        return goalWeathers.Find(x => x.weather == weather).image[index];
    }

    public Sprite getGoalSuccessImage(WeatherList.weather weather)
    {
        int i = Random.Range(0, 3);
        return goalWeathers.Find(x => x.weather == weather).successImage[i];
    }

    public Sprite getGoalSuccessImage(WeatherList.weather weather, int index)
    {
        return goalWeathers.Find(x => x.weather == weather).successImage[index];
    }

    /*
    public CardResource changeCard(CardResource c)
    {
        WeatherList.weather randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];

        c.CurrentWeather = randomWeather;

        randomWeather = allWeathers[Random.Range(0, allWeathers.Length)];
        c.needWeather = randomWeather;

        return c;
        WeatherList.weather randomWeather = (WeatherList.weather)Random.Range(0, System.Enum.GetValues(typeof(WeatherList)).Length);

         c.CurrentWeather = randomWeather;

         randomWeather = (WeatherList.weather)Random.Range(0, System.Enum.GetValues(typeof(WeatherList)).Length);
         c.needWeather = randomWeather;

         return c;
    }//*/
}
