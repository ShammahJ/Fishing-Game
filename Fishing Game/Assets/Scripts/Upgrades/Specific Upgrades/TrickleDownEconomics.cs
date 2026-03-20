using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TrickleDownEconomics : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float baseBonusAmount;
    [SerializeField] private float bonusDecrement;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (Hook.Instance.fishes.Count > 0)
        {
            List<Fish> sortedFish = Hook.Instance.fishes.OrderBy(f => f.GetOriginalValue()).ToList();

            int fishIndex = sortedFish.IndexOf(fish);

            if (fishIndex >= 0)
            {
                float bonus = Mathf.Max(0, baseBonusAmount - (fishIndex * bonusDecrement));
                return currentValue + bonus;
            }
        }

        return currentValue;
    }
}
