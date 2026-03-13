using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UpgradeIconHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ActiveUpgrade upgrade;
    [SerializeField] private float animationDuration = 0.2f;

    [Header("References")]
    [SerializeField] private Image rarityGlow;
    [SerializeField] private Image upgradeIcon;
    private RectTransform rectTransform;
    private RectTransform glowRectTransform;

    private void Awake()
    {
        rectTransform = upgradeIcon.GetComponent<RectTransform>();
        glowRectTransform = rarityGlow.GetComponent<RectTransform>();
    }


    public void Initialize(ActiveUpgrade upgrade)
    {
        this.upgrade = upgrade;

        if (rarityGlow != null && upgrade.definition != null)
        {
            rarityGlow.color = GetRarityColor(upgrade.definition.rarity);
        }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (upgrade?.definition != null)
        {
            StartCoroutine(ScaleTo(rectTransform, 100f));
            StartCoroutine(ScaleTo(glowRectTransform, 128f));
            //when we create a tooltip manager like tooltipmanager.instance.showtooltip() put it here
            //i just don't know about stacks guys
            //Debug.Log($"Hovering over: {upgrade.definition.upgradeName} (x{upgrade.stacks})");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(rectTransform, 64f));
        StartCoroutine(ScaleTo(glowRectTransform, 0f));
        //tooltipManager.instance.hidetooltip();
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
