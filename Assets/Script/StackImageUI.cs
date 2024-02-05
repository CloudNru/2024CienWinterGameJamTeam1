using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackImageUI : MonoBehaviour
{
    [Serializable]
    class BehaviorInfo
    {
        [SerializeField]
        public BehaviorObject.Behavior behavior;

        [SerializeField]
        public Sprite sprite;
    }

    [SerializeField]
    List<BehaviorInfo> spriteList = new List<BehaviorInfo>();

    [SerializeField]
    SpriteRenderer[] BehaviorIcons = new SpriteRenderer[4];

    public void UpdateUI(BehaviorStack stack)
    {
        for(int i = 0; i < stack.Count(); i++)
        {
            foreach(BehaviorInfo behavior in spriteList)
            {
                if(behavior.behavior == stack.GetBehaviorByIndex(i))
                {
                    BehaviorIcons[i].sprite = behavior.sprite;
                    break;
                }
            }
        }

        for(int i = stack.Count(); i < 4; i++)
        {
            foreach (BehaviorInfo behavior in spriteList)
            {
                if (behavior.behavior == BehaviorObject.Behavior.NULL)
                {
                    BehaviorIcons[i].sprite = behavior.sprite;
                    break;
                }
            }
        }
    }
}
