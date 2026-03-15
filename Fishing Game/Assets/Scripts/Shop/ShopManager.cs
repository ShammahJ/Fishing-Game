using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Upgrade;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Fields")]
    public float rerollCost;

    [Header("Total Upgrades")]
    public List<Upgrade> allUpgrades = new List<Upgrade>();

    [Header("Current Shop")]
    public List<Upgrade> currentShopUpgrades = new List<Upgrade>();
    public Image[] shopSlots = new Image[4];

    [Header("Tooltip")]
    public TextMeshProUGUI tooltipNameText;
    public TextMeshProUGUI tooltipDescriptionText;
    public TextMeshProUGUI tooltipCostText;
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

    public void RerollShop()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.GetMoney() >= rerollCost)
            {
                GameManager.instance.LoseMoney(rerollCost);
                RollShop();
            }
            else
            {
                StartCoroutine(PurchaseMessage(false, null));
            }
        }
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

        if (tooltipCostText != null)
            tooltipCostText.text = "$" + upgrade.cost.ToString();

        if (tooltipPanel != null)
            tooltipPanel.SetActive(true);

        if (tooltipPanel != null)
        {
            tooltipPanel.SetActive(true);
            //LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipPanel.GetComponent<RectTransform>());
        }
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

    public void PurchaseUpgrade(Upgrade upgrade, ShopSlotHover slot)
    {
        float playerMoney = GameManager.instance != null ? GameManager.instance.GetMoney() : 0;

        if (playerMoney >= upgrade.cost)
        {
            GameManager.instance.LoseMoney(upgrade.cost);

            if (UpgradeManager.Instance != null)
            {
                UpgradeManager.Instance.AddUpgrade(upgrade);
            }

            if (currentShopUpgrades.Contains(upgrade))
            {
                currentShopUpgrades.Remove(upgrade);
            }

            slot.ClearSlot();

            if (GameManager.instance != null && GameManager.instance.inventoryPanel != null)
            {
                GameManager.instance.inventoryPanel.RefreshUpgradeDisplay();
            }

            StartCoroutine(PurchaseMessage(true, upgrade));
        }
        else
        {
            //player is broke
            StartCoroutine(PurchaseMessage(false, upgrade));
        }
    }

    private IEnumerator PurchaseMessage(bool success, Upgrade upgrade)
    {
        float playerMoney = GameManager.instance != null ? GameManager.instance.GetMoney() : 0;
        if (success)
        {
            tooltipNameText.text = "";
            tooltipDescriptionText.text = "What a good consumer you are!";
            tooltipCostText.text = "";
            yield return new WaitForSeconds(1.5f);
        } else if (!success && upgrade == null)
        {
            tooltipDescriptionText.text = "You are BROKE! Can't even get a reroll!";
        } else
        {
            tooltipNameText.text = "";
            tooltipDescriptionText.text = $"You are BROKE! Need ${upgrade.cost - playerMoney}";
            tooltipCostText.text = "";
            yield return new WaitForSeconds(1.5f);
        }
    } 

    void DebugShop()
    {
        Debug.Log("Shop roll");
        foreach (Upgrade u in currentShopUpgrades)
            Debug.Log(u.upgradeName);
    }
}