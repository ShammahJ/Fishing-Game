using UnityEngine;

[CreateAssetMenu(fileName = "PolishedHook", menuName = "Upgrades/Polished Hook")]
public class PolishedHook : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime)
    {
        return currentValue + moneyBonus;
    }
}
