using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FizzBuzz", menuName = "Upgrades/FizzBuzz")]
public class FizzBuzz : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus;
    public float valMult;

    private int index = 0;

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        if (index % 3 == 0)
        {
            if (index % 5 == 0)
            {
                index++;
                return (currentValue + moneyBonus) * valMult;
            }else
            {
                index++;
                return currentValue + moneyBonus;
            }
        } else if (index % 5 == 0)
        {
            index++;
            return currentValue * valMult;
        }
        else
        {
            index++;
            return currentValue;
        }
    }
}
