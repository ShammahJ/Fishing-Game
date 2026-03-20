using UnityEngine;

[CreateAssetMenu(fileName = "WeGottaGoBald", menuName = "Upgrades/We Gotta Go Bald")]
public class WeGottaGoBald : Upgrade
{
    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        float valMult = GetMultiplier(runtime);
        return currentValue * valMult;
    }

    private float GetMultiplier(ActiveUpgrade runtime)
    {
        if (runtime.data == null)
        {
            runtime.data = UpgradeManager.Instance.activeUpgrades.Count;
        }
        return (float)runtime.data;
    }

    public override void OnLineCasted(ActiveUpgrade runtime)
    {
        if (runtime.data != null)
        {
            GetMultiplier(runtime);
        }
    }

    //public override void OnRoundEnter(ActiveUpgrade runtime)
    //{
    //    die bruh die
    //}
}
