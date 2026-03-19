using UnityEngine;

[CreateAssetMenu(fileName = "RowsAndRows", menuName = "Upgrades/Rows And Rows")]
public class RowsAndRows : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private float multVal = 1.5f;

    [Header("Shark Stat Modifiers")]
    [SerializeField] private float strengthMultiplier = 1.5f;
    [SerializeField] private float speedMultiplier = 10f;

    public override void OnFishSpawned(Fish fish, ActiveUpgrade runtime)
    {
        if (fish.GetComponent<SharkBehaviour>() != null)
        {
            fish.ModifyStats(strengthMultiplier, speedMultiplier);
        }
    }
    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (fish.GetComponent<SharkBehaviour>() != null)
        {
            return currentValue * multVal;
        }

        return currentValue;
    }
}
