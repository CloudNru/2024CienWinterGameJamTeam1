using UnityEngine;

[CreateAssetMenu(fileName = "Weather Recipe", menuName = "Scriptable Object/Weather Recipe", order = int.MaxValue)]
public class WeatherRecipe : ScriptableObject
{
    [SerializeField]
    public WeatherList.weather weather;

    [SerializeField]
    public BehaviorObject.Behavior firstBehavior;

    [SerializeField]
    public BehaviorObject.Behavior secondBehavior;

    [SerializeField]
    public BehaviorObject.Behavior thirdBehavior;
}
