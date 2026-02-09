using System.Collections.Generic;
using UnityEngine;
using static Upgrade;

public class ShopManager : MonoBehaviour
{
    [Header("Total Upgrades")]
    public List<Upgrade> allUpgrades = new List<Upgrade>();

    [Header("Current Shop")]
    public List<Upgrade> currentShopUpgrades = new List<Upgrade>();

    const float COMMON_CHANCE = 53.3f;
    const float RARE_CHANCE = 26.6f;
    const float EPIC_CHANCE = 13.3f;
    //legendary chance is 6.6%

    private void Start()
    {
        GetComponent<ShopManager>().RollShop();

    }

    public void RollShop()
    {
        currentShopUpgrades.Clear();

        for (int i = 0; i < 3; i++)
        {
            UpgradeRarity rarity = RollRarity();
            Upgrade upgrade = GetRandomUpgradeOfRarity(rarity);

            if (upgrade != null)
                currentShopUpgrades.Add(upgrade);
        }

        DebugShop();
    }

    private UpgradeRarity RollRarity()
    {
        float roll = Random.Range(0f, 100f);

        if (roll < COMMON_CHANCE)
            return UpgradeRarity.Common;

        roll -= COMMON_CHANCE;

        if (roll < RARE_CHANCE)
            return UpgradeRarity.Rare;

        roll -= RARE_CHANCE;

        if (roll < EPIC_CHANCE)
            return UpgradeRarity.Epic;

        return UpgradeRarity.Legendary;
    }

    private Upgrade GetRandomUpgradeOfRarity(UpgradeRarity rarity)
    {
        List<Upgrade> pool = allUpgrades.FindAll(x => x.rarity == rarity);

        //for now if nothing exists of that rarity just retry as Common
        if (pool.Count == 0)
            pool = allUpgrades.FindAll(x => x.rarity == UpgradeRarity.Common);

        return pool[Random.Range(0, pool.Count)];
    }

    void DebugShop()
    {
        Debug.Log("Shop roll");
        foreach (Upgrade u in currentShopUpgrades)
            Debug.Log(u.upgradeName);
    }
}