using UnityEngine;

public class UpgradeTester : MonoBehaviour
{
    public Upgrade upgrade;
    public Upgrade upgrade2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeManager.Instance.AddUpgrade(upgrade);
            Debug.Log($"Added {upgrade.name}");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpgradeManager.Instance.AddUpgrade(upgrade2);
            Debug.Log($"Added {upgrade2.name}");
        }
    }
}
