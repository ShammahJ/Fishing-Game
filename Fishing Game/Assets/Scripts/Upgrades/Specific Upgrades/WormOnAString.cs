using UnityEngine;

[CreateAssetMenu(fileName = "WormOnAString", menuName = "Upgrades/Worm On A String")]
public class WormOnAString : Upgrade
{
    [Header("Upgrade Values")]
    public float multVal = 1.5f;

    [Header("Fish Stat Modifiers")]
    [SerializeField] private float strengthMultiplier = 1.5f;
    [SerializeField] private float speedMultiplier = 0.0f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
            return currentValue * multVal;
    }

    public override void OnFishSpawned(Fish fish, ActiveUpgrade runtime)
    {
            fish.ModifyStats(strengthMultiplier, speedMultiplier);
    }
}
