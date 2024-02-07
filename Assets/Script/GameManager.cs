using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    [SerializeField]
    private List<WeatherRecipe> weatherRecipes;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private float maxTime;
    [SerializeField]
    private float time;
    [SerializeField]
    private int life;
    [SerializeField]
    private int score;

    [SerializeField]
    private TextMeshProUGUI ddayText;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Image stamp;

    public Sprite[] stampList;

    [SerializeField]
    private TextMeshProUGUI gameOverScore;

    private void Start()
    {
        Instance = this;
        maxTime = 60;
        time = 60;
        life = 3;
        score = 0;


        foreach (WeatherRecipe recipe in Resources.LoadAll<WeatherRecipe>("WeatherRecipe"))
        {
            weatherRecipes.Add(recipe);
        }

        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if (time <= 0)
        {
            if(score >= 30)
            {
                GameClear();
            }
            else
            {
                GameOver();
            }
        }
        time -= Time.deltaTime;
        slider.value = time / maxTime;
        scoreText.text = score + "점";
        if(life > 0) { 
            ddayText.text = ("D-" + life);
        }
        else if(life == 0)
        {
            ddayText.text = ("D-day");
            GameOver();
            Time.timeScale = 0;
        }
    }

    public WeatherRecipe isGoodRecipe(BehaviorObject.Behavior first, BehaviorObject.Behavior second, BehaviorObject.Behavior third)
    {
        foreach(var recipe in weatherRecipes)
        {
            if(recipe.firstBehavior == first)
            {
                if(recipe.secondBehavior == second)
                {
                    if(recipe.thirdBehavior == third)
                    {
                        return recipe;
                    }
                }
            }
        }

        return null;
    }

    public WeatherRecipe FindRecipe(WeatherList.weather weather) 
    {
        foreach(WeatherRecipe recipe in weatherRecipes)
        {
            if(recipe.weather == weather)
            {
                return recipe;
            }
        }

        return null;
    }

    public static GameManager getInstance() //�̱���
    {
        if(Instance == null)
        {
            Object lockObject = new Object();
            lock (lockObject)
            {
                if(Instance == null)
                {
                    Instance = new GameManager();
                }
                return Instance;
            }
        }
        else
        {
            return Instance;
        }
    }

    void call()
    {
        foreach (WeatherRecipe recipe in Resources.LoadAll<WeatherRecipe>("WeatherRecipe"))
        {
            weatherRecipes.Add(recipe);
        }
    }

    public void AddTime(int n)
    {
        time += n;
    }

    public void SubtractTime(int n)
    {
        time -= n;
    }

    public void AddScore(int n)
    {
        score += n;
    }

    public void SubtractScore(int n)
    {
        score -= n;
    }

    public void RecoverLife() //��� +1
    {
        RecoverLife(1);
    }

    public void RecoverLife(int n) //��� +n
    {
        life += n;
        if(life < 3)
        {
            life = 3;
        }
    }

    public void LoseLife() //��� -1
    {
        LoseLife(1);
    }

    public void LoseLife(int n) //��� -n
    {
        life -= n;
        if(life <= 0)
        {
            GameOver();
        }
    }

    private void GameClear()
    {
        gameOverScore.text = (score + "점!");
        gameOverPanel.SetActive(true);
        stamp.sprite = stampList[0];
        Debug.Log("You Win!");
    }

    private void GameOver()
    {
        gameOverScore.text = (score + "점!");
        gameOverPanel.SetActive(true);
        stamp.sprite = stampList[1];
        Debug.Log("You Lose...");
    }
}