using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    [SerializeField]
    private List<WeatherRecipe> weatherRecipes;

    [SerializeField]
    private float time;
    [SerializeField]
    private int life;
    [SerializeField]
    private int score;

    private void Start()
    {
        Instance = this;
        time = 60;
        life = 3;
        score = 0;

        foreach (WeatherRecipe recipe in Resources.LoadAll<WeatherRecipe>("WeatherRecipe"))
        {
            weatherRecipes.Add(recipe);
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

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            //GameOver();
        }
        time -= Time.deltaTime;
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
        Debug.Log("You Win!");
    }

    private void GameOver()
    {
        Debug.Log("You Lose...");
    }
}