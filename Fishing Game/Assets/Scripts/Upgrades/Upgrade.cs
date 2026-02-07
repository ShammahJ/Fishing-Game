using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class Upgrade : ScriptableObject
{
    [Header("Upgrade Info")]
    public string id;
    public string upgradeName;
    public float cost;
    public int rarity;

    [TextArea]
    public string description;
    public Sprite icon;

    //Different virtual methods for different upgrade types, upgrades will only used the virtual methods they care about
    //Value pipelines
    public virtual float ModifyFishValue(float currentValue, ActiveUpgrade runtime)
    {
        return currentValue;
    }

        //Game events
        public virtual void OnUpgradeAdded(ActiveUpgrade runtime) { }
        public virtual void OnUpgradeRemoved(ActiveUpgrade runtime) { }

        public virtual void OnFishSpawned(Fish fish, ActiveUpgrade runtime) { }
        public virtual void OnFishCaught(Fish fish, ActiveUpgrade runtime) { }

        //World modifiers
        //later

}
