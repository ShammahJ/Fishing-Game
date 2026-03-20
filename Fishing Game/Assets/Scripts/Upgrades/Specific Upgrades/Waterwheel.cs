using UnityEngine;

[CreateAssetMenu(fileName = "Waterwheel", menuName = "Upgrades/Waterwheel")]
public class Waterwheel : Upgrade
{
    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime)
    {
        return currentValue + Hook.Instance.fishes.Count;
    }
}
