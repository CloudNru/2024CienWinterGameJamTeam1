using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance; //教臂沛

    private float time;
    private int life;
    private int score;

    GameManager() {
        time = 60;
        life = 3;
        score = 0;
    }

    public static GameManager getInstance()
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
            GameOver();
        }
        time -= Time.deltaTime;
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

    public void RecoverLife() //格见 +1
    {
        RecoverLife(1);
    }

    public void RecoverLife(int n) //格见 +n
    {
        life += n;
        if(life < 3)
        {
            life = 3;
        }
    }

    public void LoseLife() //格见 -1
    {
        LoseLife(1);
    }

    public void LoseLife(int n) //格见 -n
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
        Instance = null;
    }
}