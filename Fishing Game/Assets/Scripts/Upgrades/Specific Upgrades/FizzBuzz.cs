using System;
using UnityEngine;

public class FizzBuzz : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus = 50f;
    public float valMult = 3f;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        //get or create the runtime data
        if (runtime.data == null)
            runtime.data = 0;

        int index = (int)runtime.data;
        runtime.data = index + 1;

        bool isFizz = (index % 3 == 0);
        bool isBuzz = (index % 5 == 0);

        if (isFizz && isBuzz)
        {
            return (currentValue + moneyBonus) * valMult;
        }
        else if (isFizz)
        {
            return currentValue + moneyBonus;
        }
        else if (isBuzz)
        {
            return currentValue * valMult;
        }
        else
        {
            return currentValue;
        }
    }
}
