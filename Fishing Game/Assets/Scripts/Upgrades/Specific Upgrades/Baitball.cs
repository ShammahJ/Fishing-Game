using UnityEngine;

[CreateAssetMenu(fileName = "Baitball", menuName = "Upgrades/Baitball")]
public class Baitball : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (fish.GetComponent<SharkBehaviour>() == null &&
            fish.GetComponent<ClownfishBehaviour>() == null &&
            fish.GetComponent<FshBehaviour>() == null &&
            fish.GetComponent<FishhsiFBehaviour>() == null)
        {
            return currentValue + moneyBonus;
        }
        return currentValue;
    }
}
