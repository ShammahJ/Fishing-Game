using System.Collections.Generic;
using UnityEngine;

public class TheChosenFew : Upgrade
{
    [Header("Upgrade Values")]
    public float bonusPerCatch = 0.1f;
    public float defaultMultiplier = 1f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        float currentMult = GetMultiplier(runtime);
        return currentValue * currentMult;
    }

    public override void OnHookRetrieved(List<Fish> caughtFish, ActiveUpgrade runtime)
    {
        float currentMult = GetMultiplier(runtime);

        if (caughtFish.Count <= 4)
        {
            float newMult = currentMult + bonusPerCatch;
            SetMultiplier(runtime, newMult);
        }
        else
        {
            SetMultiplier(runtime, defaultMultiplier);
        }
    }

    private float GetMultiplier(ActiveUpgrade runtime)
    {
        if (runtime.data == null)
        {
            runtime.data = defaultMultiplier;
        }
        return (float)runtime.data;
    }

    private void SetMultiplier(ActiveUpgrade runtime, float value)
    {
        runtime.data = value;
    }
}
