using UnityEngine;

[CreateAssetMenu(fileName = "Monogamy", menuName = "Upgrades/Monogamy")]
public class Monogamy : Upgrade
{
    [Header("Upgrade Values")]
    public float valMult;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (Hook.Instance.fishes.Count == 1)
        {
            return currentValue * valMult;
        }
        return currentValue;
    }
}
