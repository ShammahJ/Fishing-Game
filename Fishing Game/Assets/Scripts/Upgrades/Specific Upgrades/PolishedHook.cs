using UnityEngine;

public class PolishedHook : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        return currentValue + moneyBonus;
    }
}
