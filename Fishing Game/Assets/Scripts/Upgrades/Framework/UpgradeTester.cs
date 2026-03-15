using UnityEngine;

public class UpgradeTester : MonoBehaviour
{
    public Upgrade upgrade;
    public Upgrade upgrade2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpgradeManager.Instance.AddUpgrade(upgrade);
            Debug.Log($"Added {upgrade.name}");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpgradeManager.Instance.AddUpgrade(upgrade2);
            Debug.Log($"Added {upgrade2.name}");
        }
    }
}
