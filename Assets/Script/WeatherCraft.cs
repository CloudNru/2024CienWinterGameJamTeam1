using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeatherCraft
{
    public static WeatherList.weather CraftingWeather(WeatherList.weather nowWeather, BehaviorStack behaviors)
    {
        List<BehaviorObject.Behavior> behaviorList = new List<BehaviorObject.Behavior>();
        WeatherRecipe recipe = GameManager.getInstance().FindRecipe(nowWeather);
        if (recipe != null)
        {
            if(recipe.firstBehavior != BehaviorObject.Behavior.NULL)
            {
                behaviorList.Add(recipe.firstBehavior);
                if (recipe.secondBehavior != BehaviorObject.Behavior.NULL)
                {
                    behaviorList.Add(recipe.secondBehavior);
                    if (recipe.thirdBehavior != BehaviorObject.Behavior.NULL)
                    {
                        behaviorList.Add(recipe.thirdBehavior);
                    }
                }
            }
        }

        for(int i = 0; i < behaviors.Count(); i++)
        {
            BehaviorObject.Behavior behavior = behaviors.GetBehaviorByIndex(i);
            if (behavior == BehaviorObject.Behavior.Eraser)
            {
                behaviorList.Clear();
            }
            else
            {
                behaviorList.Add(behavior);
            }
        }

        if(behaviorList.Count < 3)
        {
            int n = 3 - behaviorList.Count;
            for (int i = 0; i < n; i++)
            {
                behaviorList.Add(BehaviorObject.Behavior.NULL);
            }
        }
        behaviors.Clear(); 

        string s = "";
        foreach(BehaviorObject.Behavior behavior in behaviorList)
        {
            s += behavior.ToString() + " ";
        }
        Debug.Log(s);

        recipe = GameManager.getInstance().isGoodRecipe(behaviorList[0], behaviorList[1], behaviorList[2]);
        if (behaviorList.Count > 3 || recipe == null)
        {
            return WeatherList.weather.NULL;
        }
        else
        {
            return recipe.weather;
        }
    }
}