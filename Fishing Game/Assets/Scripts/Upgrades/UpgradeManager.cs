using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<ActiveUpgrade> activeUpgrades = new();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        ActiveUpgrade existing = activeUpgrades.Find(x => x.definition == upgrade);

        if (existing != null)
        {
            existing.stacks++;
        }
        else
        {
            existing = new ActiveUpgrade(upgrade);
            activeUpgrades.Add(existing);
        }

        upgrade.OnUpgradeAdded(existing);
    }


    public void RemoveUpgrade(Upgrade upgrade)
    {
        ActiveUpgrade existing = activeUpgrades.Find(x => x.definition == upgrade);

        if (existing == null)
            return;

        existing.stacks--;

        if (existing.stacks <= 0)
            activeUpgrades.Remove(existing);
    }

    public float ModifyFishValue(float baseValue)
    {
        float value = baseValue;

        foreach (ActiveUpgrade upgrade in activeUpgrades)
        {
            value = upgrade.definition.ModifyFishValue(value, upgrade);
        }

        return value;
    }

    public void NotifyFishCaught(Fish fish)
    {
        foreach (ActiveUpgrade upgrade in activeUpgrades)
        {
            upgrade.definition.OnFishCaught(fish, upgrade);
        }
    }

}
