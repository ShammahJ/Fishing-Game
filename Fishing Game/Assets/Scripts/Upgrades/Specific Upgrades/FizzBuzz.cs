using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FizzBuzz", menuName = "Upgrades/FizzBuzz")]
public class FizzBuzz : Upgrade
{
    [Header("Upgrade Values")]
    public float moneyBonus = 50f;
    public float valMult = 3f;

    //we're using a class inside a scriptable object isn't that scary
    [System.Serializable]
    private class FizzBuzzData
    {
        public int index = 0;
    }

    public override float ModifyFishValue(float currentValue, ActiveUpgrade runtime, Fish fish)
    {
        //get or create the runtime data
        FizzBuzzData data = runtime.data as FizzBuzzData;
        if (data == null)
        {
            data = new FizzBuzzData();
            runtime.data = data;
        }

        int currentIndex = data.index;
        data.index++;

        bool isFizz = (currentIndex % 3 == 0);
        bool isBuzz = (currentIndex % 5 == 0);

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
