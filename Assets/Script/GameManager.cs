using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //�̱���

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

    public void RecoverLife() //��� +1
    {
        
    }

    public void RecoverLife(int n) //��� +n
    {
        
    }

    public void LoseLife() //��� -1
    {

    }

    public void LoseLife(int n) //��� -n
    {

    }
}