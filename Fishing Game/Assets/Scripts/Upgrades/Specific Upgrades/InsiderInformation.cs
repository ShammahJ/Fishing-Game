using UnityEngine;

[CreateAssetMenu(fileName = "InsiderInformation", menuName = "Upgrades/Insider Information")]
public class InsiderInformation : Upgrade
{
    [Header ("Upgrade Values")]
    public float multVal = 0.35f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime)
    {
        if (FishManager.instance.gameObject.transform.childCount < 8)
        {
            float multVal = GetMultiplier(runtime);
            return currentValue * multVal;
        }
        else
        {
            return currentValue;
        }
    }

    private float GetMultiplier(ActiveUpgrade runtime)
    {
        if (runtime.data == null)
        {
            runtime.data = 1 + ((8 - FishManager.instance.gameObject.transform.childCount) * multVal);
        }
        return (float)runtime.data;
    }
}
