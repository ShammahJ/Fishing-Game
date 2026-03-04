using UnityEngine;

[CreateAssetMenu(fileName = "TheChosenFew", menuName = "Upgrades/The Chosen Few")]
public class TheChosenFew : Upgrade
{
    [Header("Upgrade Values")]
    public float valMult;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        Increment();
        return currentValue * valMult;
    }

    private void Increment()
    {
        if (Hook.Instance.fishes.Count <= 4)
        {
            valMult += 0.1f;
        } else
        {
            valMult = 1f;
        }
    }
}
