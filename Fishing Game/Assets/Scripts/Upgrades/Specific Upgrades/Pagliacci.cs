using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Pagliacci", menuName = "Upgrades/Pagliacci")]
public class Pagliacci : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float moneyBonus = 15f;
    [SerializeField] private float minPenaltyAmount = 5f;
    [SerializeField] private float maxPenaltyAmount = 50f;

    //runtime data to track if we've already applied the effect this catch
    [System.Serializable]
    private class ClownfishData
    {
        public bool effectApplied = false;
        public bool wasBonus = false;
        public int clownfishCount = 0;
    }

    public override void OnHookRetrieved(List<Fish> caughtFish, ActiveUpgrade runtime)
    {
        //get or create runtime data
        ClownfishData data = runtime.data as ClownfishData;
        if (data == null)
        {
            data = new ClownfishData();
            runtime.data = data;
        }

        int clownfishCount = 0;
        foreach (Fish fish in caughtFish)
        {
            if (fish.GetComponent<ClownfishBehaviour>() != null)
            {
                clownfishCount++;
            }
        }

        data.clownfishCount = clownfishCount;
        data.effectApplied = true;

        if (clownfishCount >= 2)
        {
            data.wasBonus = true;
        }
        else if (clownfishCount == 1)
        {
            data.wasBonus = false;
        }
        else
        {
            data.effectApplied = false;
        }
    }

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        ClownfishData data = runtime.data as ClownfishData;

        if (data == null || !data.effectApplied)
            return currentValue;

        float penaltyAmount = Random.Range(minPenaltyAmount, maxPenaltyAmount);

        if (data.wasBonus)
        {
            return currentValue + moneyBonus;
        }
        else
        {
            return currentValue - penaltyAmount;
        }
    }

    //public override void OnFishCaught(Fish fish, ActiveUpgrade runtime)
    //{
    //    //resets when fish are collected
    //    if (runtime.data != null)
    //    {
    //        ((ClownfishData)runtime.data).effectApplied = false;
    //    }
    //}

    public override void OnLineCasted(ActiveUpgrade runtime)
    {
        //resets on new cast
        if (runtime.data != null)
        {
            ((ClownfishData)runtime.data).effectApplied = false;
        }
    }
}
