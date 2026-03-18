using UnityEngine;

[CreateAssetMenu(fileName = "GrandFinale", menuName = "Upgrades/Grand Finale")]
public class GrandFinale : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float bonusAmount = 18f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (GameManager.instance.GetLives() == 1)
        {
            if (Hook.Instance != null && Hook.Instance.fishes != null)
            {
                Fish lastFish = Hook.Instance.fishes[Hook.Instance.fishes.Count - 1];

                if (lastFish == fish)
                {
                    return currentValue + bonusAmount;
                }
            }
        }

        return currentValue;
    }
}
