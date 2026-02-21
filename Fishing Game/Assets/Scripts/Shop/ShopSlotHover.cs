using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ShopSlotHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float animationDuration = 0.2f;
    [SerializeField] private Image upgradeGlow;

    private RectTransform glowRectTransform;

    private Upgrade assignedUpgrade;
    private ShopManager shopManager;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        glowRectTransform = upgradeGlow.GetComponent<RectTransform>();
    }

    private void Update()
    {
        upgradeGlow.rectTransform.Rotate(0, 0, -45f * Time.deltaTime);
    }

    public void Initialize(Upgrade upgrade, ShopManager manager)
    {
        assignedUpgrade = upgrade;
        shopManager = manager;

        if (upgradeGlow != null && assignedUpgrade != null)
        {
            upgradeGlow.color = GetRarityColor(assignedUpgrade.rarity);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(rectTransform, 100f));
        if (assignedUpgrade != null && shopManager != null)
            shopManager.ShowTooltip(assignedUpgrade);
        StartCoroutine(ScaleTo(glowRectTransform, 150f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(rectTransform, 75f));
        if (shopManager != null)
            shopManager.HideTooltip();
        StartCoroutine(ScaleTo(glowRectTransform, 0f));
    }

    private Color GetRarityColor(Upgrade.UpgradeRarity rarity)
    {
        switch (rarity)
        {
            case Upgrade.UpgradeRarity.Common:
                return new Color(0.68f, 0.94f, 0.698f);
            case Upgrade.UpgradeRarity.Rare:
                return new Color(0.4f, 0.855f, 0.937f);
            case Upgrade.UpgradeRarity.Epic:
                return new Color(0.75f, 0.545f, 0.953f);
            case Upgrade.UpgradeRarity.Legendary:
                return new Color(0.953f, 0.878f, 0.474f);
            default:
                return Color.white;
        }
    }

    private IEnumerator ScaleTo(RectTransform rectTransform, float targetSize)
    {
        Vector2 startSize = rectTransform.sizeDelta;
        Vector2 targetSizeDelta = new Vector2(targetSize, targetSize);
        float timer = 0f;

        while (timer < animationDuration)
        {
            timer += Time.deltaTime;
            float t = timer / animationDuration;
            t = Mathf.SmoothStep(0, 1, t);

            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSizeDelta, t);
            yield return null;
        }

        rectTransform.sizeDelta = targetSizeDelta;
    }
}