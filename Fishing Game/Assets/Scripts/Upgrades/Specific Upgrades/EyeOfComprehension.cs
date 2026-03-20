using UnityEngine;

[CreateAssetMenu(fileName = "EyeOfComprehension", menuName = "Upgrades/Eye Of Comprehension")]
public class EyeOfComprehension : Upgrade
{
    public float moneyBonus;
    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (fish.GetComponent<FishhsiFBehaviour>() != null || fish.GetComponent<FshBehaviour>() != null)
        {
            return currentValue + moneyBonus;
        }

        return currentValue;
    }
}
