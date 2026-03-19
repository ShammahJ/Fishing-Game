using UnityEngine;

[CreateAssetMenu(fileName = "Jumpstart", menuName = "Upgrades/Jumpstart")]
public class Jumpstart : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;
    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (FishManager.instance.GetLives() == 5)
        {
            return currentValue + moneyBonus;
        }
        return currentValue;
    }
}
