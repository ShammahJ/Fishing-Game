using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Upgrade;

public class ShopManager : MonoBehaviour
{
    [Header("Total Upgrades")]
    public List<Upgrade> allUpgrades = new List<Upgrade>();

    [Header("Current Shop")]
    public List<Upgrade> currentShopUpgrades = new List<Upgrade>();
    public Image[] shopSlots = new Image[4];

    [Header("Tooltip")]
    public TextMeshProUGUI tooltipNameText;
    public TextMeshProUGUI tooltipDescriptionText;
    public GameObject tooltipPanel;

    const float COMMON_CHANCE = 53.3f;
    const float RARE_CHANCE = 26.6f;
    const float EPIC_CHANCE = 13.3f;
    //legendary chance is 6.6%

    private void Start()
    {
        RollShop();
        HideTooltip();
    }

    public void RollShop()
    {
        currentShopUpgrades.Clear();
        ClearShopVisuals();

        for (int i = 0; i < shopSlots.Length; i++)
        {
            UpgradeRarity rarity = RollRarity();
            Upgrade upgrade = GetRandomUpgradeOfRarity(rarity);

            if (upgrade != null)
            {
                currentShopUpgrades.Add(upgrade);
                SetShopVisual(upgrade, i);
                AddTooltipToSlot(upgrade, i);
            }
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

        //default case is the common rarity, doubt this will ever see us tho
        if (pool.Count == 0)
            pool = allUpgrades.FindAll(x => x.rarity == UpgradeRarity.Common);

        return pool[Random.Range(0, pool.Count)];
    }

    void SetShopVisual(Upgrade upgrade, int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < shopSlots.Length)
        {
            Image slotImage = shopSlots[slotIndex];
            if (slotImage != null)
            {
                slotImage.sprite = upgrade.icon;
                slotImage.preserveAspect = true;
            }
        }
    }

    void ClearShopVisuals()
    {
        foreach (Image slot in shopSlots)
        {
            if (slot != null)
            {
                slot.sprite = null;
            }
        }
    }

    void AddTooltipToSlot(Upgrade upgrade, int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < shopSlots.Length)
        {
            Image slotImage = shopSlots[slotIndex];
            if (slotImage != null)
            {
                slotImage.raycastTarget = true;
                ShopSlotHover tooltip = slotImage.gameObject.GetComponent<ShopSlotHover>();
                if (tooltip == null)
                    tooltip = slotImage.gameObject.AddComponent<ShopSlotHover>();

                tooltip.Initialize(upgrade, this);
            }
        }
    }

    public void ShowTooltip(Upgrade upgrade)
    {
        if (tooltipNameText != null)
            tooltipNameText.text = upgrade.upgradeName;

        if (tooltipDescriptionText != null)
            tooltipDescriptionText.text = upgrade.description;

        if (tooltipPanel != null)
            tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        if (tooltipPanel != null)
            tooltipPanel.SetActive(false);
        else
        {
            if (tooltipNameText != null)
                tooltipNameText.text = "";
            if (tooltipDescriptionText != null)
                tooltipDescriptionText.text = "";
        }
    }

    void DebugShop()
    {
        Debug.Log("Shop roll");
        foreach (Upgrade u in currentShopUpgrades)
            Debug.Log(u.upgradeName);
    }
}