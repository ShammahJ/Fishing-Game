using UnityEngine;

public enum FishRarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

[System.Serializable]
public class FishIdentity
{

    public string objectName;

    [Header("Spawn")]
    public int weight;       // Base of rarity
    public FishRarity rarity;

    [Header("Economy")]
    public int baseValue;

    [Header("Stats")]
    public float baseSpeed;
    public float baseStrength;
    // If we decide to factor in physical weight of the fish to the value
    //public float baseSize;

    // If we also decide to have fish icons, kinda like IDs
    //[Header("Visual")]
    //public Sprite sprite;

    [Header("Fish Prefab")]
    public GameObject fishPrefab;

    public bool isNothing;
}
