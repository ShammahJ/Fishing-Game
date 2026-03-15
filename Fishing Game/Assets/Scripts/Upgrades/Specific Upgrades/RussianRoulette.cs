using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RussianRoulette", menuName = "Upgrades/Russian Roulette")]
public class RussianRoulette : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float successBonus = 18f;
    [SerializeField][Range(0f, 1f)] private float failChance = 1f / 6f; 
    [SerializeField] private float failMultiplier = 0f;

    //class to hold runtime data, specifically booleans so that instances are diffrentiated from other instances
    [System.Serializable]
    private class RouletteData
    {
        public bool isSuccess = false;
    }

    public override void OnHookRetrieved(List<Fish> caughtFish, ActiveUpgrade runtime)
    {
        //get or create runtime data
        RouletteData data = runtime.data as RouletteData;
        if (data == null)
        {
            data = new RouletteData();
            runtime.data = data;
        }

        float roll = Random.Range(0f, 1f);
        data.isSuccess = roll >= failChance; //5/6 chance of success
    }

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        RouletteData data = runtime.data as RouletteData;

        if (data.isSuccess)
        {
            return currentValue + successBonus;
        }
        else
        {
            return currentValue * failMultiplier;
        }
    }
}