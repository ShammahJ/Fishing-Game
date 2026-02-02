using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    [Header("Upgrade Info")]
    public string id;
    public string upgradeName;
    public float cost;

    [TextArea]
    public string description;
    public Sprite icon;

    //Called when the upgrade is picked up / activated

    //When coding starts put down the player as a parameter, like (Player player) {
    public virtual void OnEquip()
    {
        // blah
    }

    //Called when the upgrade is removed / deactivated
    //When you sell the upgrade, do not destroy the scriptable object and instead remove the ref
    public virtual void OnUnequip()
    {
        // blah
    }
}
