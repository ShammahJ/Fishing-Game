using UnityEngine;

public class CherryOnTop : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float valueMultiplier = 1.5f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (FishManager.instance.GetLives() == 1)
        {
            if (Hook.Instance != null && Hook.Instance.fishes != null && Hook.Instance.fishes.Count == 1)
            {
                return currentValue * valueMultiplier;
            }
        }

        return currentValue;
    }
}