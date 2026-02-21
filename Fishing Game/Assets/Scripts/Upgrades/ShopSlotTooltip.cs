using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ShopSlotHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float animationDuration = 0.2f;
    [SerializeField] private Image upgradeGlow;

    private Upgrade assignedUpgrade;
    private ShopManager shopManager;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Initialize(Upgrade upgrade, ShopManager manager)
    {
        assignedUpgrade = upgrade;
        shopManager = manager;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(100f));
        if (assignedUpgrade != null && shopManager != null)
            shopManager.ShowTooltip(assignedUpgrade);
        upgradeGlow.rectTransform.Rotate(Vector3.forward * 90f * Time.deltaTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(75f));
        if (shopManager != null)
            shopManager.HideTooltip();
    }

    private IEnumerator ScaleTo(float targetSize)
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