using UnityEngine;

public class UpgradeTester : MonoBehaviour
{
    public Upgrade polishedHook;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpgradeManager.Instance.AddUpgrade(polishedHook);
            Debug.Log("Added Polished Hook");
        }
    }
}
