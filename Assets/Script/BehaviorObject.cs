using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BehaviorObject : MonoBehaviour
{
    public enum Behavior { NULL, Eraser, Cloud, Water, Ice, Bulb, Wind, Socket, Smoke, Error  };
    public static string[] BehaviorName = new string[]{ "NULL", "Eraser", "Cloud", "Water", "Ice", "Bulb", "Wind", "Socket", "Smoke", "Error"};

    [SerializeField]
    private BehaviorStack stack;

    [SerializeField]
    private Behavior myBehavior;

    public void addStack()
    {
        stack.AddStack(myBehavior);
    }
}
