using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Encore", menuName = "Upgrades/Encore")]
public class Encore : Upgrade
{
    [Header("Upgrade Values")]
    [SerializeField] private int requiredFishCount = 6;

    //runtime data class
    [System.Serializable]
    private class EncoreData
    {
        public bool hasTriggered = false; //tracks if this instance has already triggered
    }

    public override void OnHookRetrieved(List<Fish> caughtFish, ActiveUpgrade runtime)
    {
        //get or create runtime data
        EncoreData data = runtime.data as EncoreData;
        if (data == null)
        {
            data = new EncoreData();
            runtime.data = data;
        }

        if (data.hasTriggered)
            return;

        if (caughtFish.Count >= requiredFishCount)
        {
            if (FishManager.instance != null)
            {
                FishManager.instance.AddLife();
                
                data.hasTriggered = true;
            }
        }
    }
}