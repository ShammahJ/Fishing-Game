using UnityEngine;

public class MidasHook : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (Hook.Instance.fishes[0] == fish)
        {
            return currentValue * moneyBonus;
        } 
        return currentValue;
    }
}
