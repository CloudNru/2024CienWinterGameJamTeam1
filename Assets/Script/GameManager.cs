using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //教臂沛

    private float time;
    private int Life;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecoverLife() //格见 +1
    {
        
    }

    public void RecoverLife(int n) //格见 +n
    {
        
    }

    public void LoseLife() //格见 -1
    {

    }

    public void LoseLife(int n) //格见 -n
    {

    }
}