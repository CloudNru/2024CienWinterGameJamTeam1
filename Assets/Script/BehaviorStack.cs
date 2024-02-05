using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BehaviorStack : MonoBehaviour
{
    private const int STACKMAXSIZE = 4;

    [SerializeField]
    BehaviorObject.Behavior[] stack = new BehaviorObject.Behavior[STACKMAXSIZE];

    [SerializeField] 
    int size = 0;

    [SerializeField]
    StackImageUI ui;

    public BehaviorObject.Behavior GetBehaviorByIndex(int index)
    {
        if(index < 0 || index >= stack.Length)
        {
            return BehaviorObject.Behavior.NULL;
        }

        return stack[index];
    }

    public void AddStack(BehaviorObject.Behavior behavior)
    {
        if(size < STACKMAXSIZE)
        {
            stack[size] = behavior;
            size++;
            UpdateUI();
        }
    }

    public void SubtractStack(int index)
    {
        for(int i = index; i < STACKMAXSIZE - 1; i++)
        {
            stack[i] = stack[i + 1];
        }

        stack[3] = BehaviorObject.Behavior.NULL;

        size--;
        if(size < 0)
        {
            size = 0;
        }

        UpdateUI();
    }

    public int Count() { return size; }

    public void UpdateUI()
    {
        if(ui != null)
        {
            ui.UpdateUI(this);
        }
    }
}