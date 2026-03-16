using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UpgradeInventoryPanel : MonoBehaviour
{
    [Header("Panel Settings")]
    [SerializeField] private GameObject panelContainer; //the panel
    [SerializeField] private Transform upgradeGridParent; //object with GridLayoutGroup
    [SerializeField] private GameObject upgradeIconPrefab; //the icon prefab

    [Header("Grid Settings")]
    [SerializeField] private int upgradesPerRow = 12; //amount of upgrades displayed in a single row
    [SerializeField] private float iconSize = 64f;
    [SerializeField] private float rowSpacing = 10f;

    [Header("References")]
    [SerializeField] private Text instructionText;

    private GridLayoutGroup gridLayout;
    private bool isPanelOpen = false;
    private List<GameObject> currentIcons = new List<GameObject>();
    private ContentSizeFitter contentSizeFitter;

    private void Start()
    {
        SetupGridParent();
        if (panelContainer != null)
            panelContainer.SetActive(false);
    }

    private void SetupGridParent()
    {
        if (upgradeGridParent == null) return;

        RectTransform gridRect = upgradeGridParent.GetComponent<RectTransform>();
        if (gridRect == null)
            upgradeGridParent.gameObject.AddComponent<RectTransform>();

        //set anchor/stretch properly
        //gridRect.anchorMin = new Vector2(0, 1);
        //gridRect.anchorMax = new Vector2(1, 1); 
        //gridRect.pivot = new Vector2(0.5f, 1); 
        gridRect.offsetMin = Vector2.zero;
        gridRect.offsetMax = Vector2.zero;

        //so god help me
        gridLayout = upgradeGridParent.GetComponent<GridLayoutGroup>();
        if (gridLayout == null)
            gridLayout = upgradeGridParent.gameObject.AddComponent<GridLayoutGroup>();

        //grid config
        gridLayout.cellSize = new Vector2(iconSize, iconSize);
        gridLayout.spacing = new Vector2(rowSpacing, rowSpacing);
        //gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = upgradesPerRow;
        //gridLayout.startAxis = GridLayoutGroup.Axis.Horizontal;
        gridLayout.childAlignment = TextAnchor.UpperLeft;

        contentSizeFitter = upgradeGridParent.GetComponent<ContentSizeFitter>();
        if (contentSizeFitter == null)
            contentSizeFitter = upgradeGridParent.gameObject.AddComponent<ContentSizeFitter>();

        //contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        //contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    }

    // private void FixedUpdate()
    //{
    //    RefreshUpgradeDisplay();
    //}

    public void TogglePanel()
    {
        isPanelOpen = !isPanelOpen;

        if (isPanelOpen)
        {
            RefreshUpgradeDisplay();
            panelContainer.SetActive(true);
            instructionText.gameObject.SetActive(false);
        }
        else
        {
            panelContainer.SetActive(false);
            instructionText.gameObject.SetActive(true);
        }
    }

    public void RefreshUpgradeDisplay()
    {
        ClearIcons();

        if (UpgradeManager.Instance == null) return;

        List<ActiveUpgrade> upgrades = UpgradeManager.Instance.activeUpgrades;

        foreach (ActiveUpgrade upgrade in upgrades)
        {
            CreateUpgradeIcon(upgrade);
        }

        //force layout rebuild
        LayoutRebuilder.ForceRebuildLayoutImmediate(upgradeGridParent.GetComponent<RectTransform>());

        ResizePanelToFit(upgrades.Count);
    }

    private void CreateUpgradeIcon(ActiveUpgrade upgrade)
    {
        if (upgradeIconPrefab == null || upgradeGridParent == null) return;

        GameObject iconObj = Instantiate(upgradeIconPrefab, upgradeGridParent);

        //reset local position and scale
        iconObj.transform.localPosition = Vector3.zero;
        iconObj.transform.localScale = Vector3.one;

        currentIcons.Add(iconObj);

        Transform upgradeIconTransform = iconObj.transform.Find("UpgradeIcon");
        if (upgradeIconTransform != null)
        {
            Image iconImage = upgradeIconTransform.GetComponent<Image>();
            if (iconImage != null && upgrade.definition != null)
            {
                iconImage.sprite = upgrade.definition.icon;
                iconImage.preserveAspect = true;
            }
        }

        // Uncomment when you're ready to test stacks
        //TextMeshProUGUI stackText = iconObj.transform.Find("StackCountText")?.GetComponent<TextMeshProUGUI>();
        //if (stackText != null)
        //{
        //    if (upgrade.stacks > 1)
        //        stackText.text = upgrade.stacks.ToString();
        //    else
        //        stackText.text = "";
        //}

        UpgradeIconHandler handler = iconObj.GetComponent<UpgradeIconHandler>();
        if (handler == null)
            handler = iconObj.AddComponent<UpgradeIconHandler>();

        handler.Initialize(upgrade);
    }

    private void ClearIcons()
    {
        foreach (GameObject icon in currentIcons)
        {
            if (icon != null)
                Destroy(icon);
        }
        currentIcons.Clear();
    }

    private void ResizePanelToFit(int upgradeCount)
    {
        Canvas.ForceUpdateCanvases();
    }
}
