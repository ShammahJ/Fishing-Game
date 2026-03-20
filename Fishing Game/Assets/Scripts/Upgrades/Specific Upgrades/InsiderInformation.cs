using UnityEngine;

[CreateAssetMenu(fileName = "InsiderInformation", menuName = "Upgrades/Insider Information")]
public class InsiderInformation : Upgrade
{
    [Header ("Upgrade Values")]
    public float multVal = 0.35f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime)
    {
        float multVal = GetMultiplier(runtime);
        return currentValue * multVal;
    }

    private float GetMultiplier(ActiveUpgrade runtime)
    {
        if (runtime.data == null)
        {
            runtime.data = 1 + (FishManager.instance.gameObject.transform.childCount * multVal);
        }
        return (float)runtime.data;
    }
}
