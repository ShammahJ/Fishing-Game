using System;
using System.Collections.Generic;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    
    [SerializeField] private List<WeightedFish> beachFish;
    [SerializeField] private List<WeightedFish> clearFish;
    [SerializeField] private List<WeightedFish> swampFish;
    [SerializeField] private List<WeightedFish> rainyFish;
    // private void Start()
    // {
    //     SetBiome(GameManager.instance.biome);
    // }

    [SerializeField] private FishManager fishManager;
    [SerializeField] private GameObject seaweed;
    public void SetBiome(string biome)
    {
        print("set biome: " + biome);
        seaweed.SetActive(false);
        switch (biome) {
            case "Beach":
                fishManager.fishPrefabs = beachFish;
                fishManager.fishPerSecond = 2f;
                break;
            case "Clear":
                fishManager.fishPrefabs = clearFish;
                fishManager.fishPerSecond = 1f;
                break;
            case "Swamp":
                fishManager.fishPrefabs = swampFish;
                fishManager.fishPerSecond = 2.5f;
                seaweed.SetActive(true);
                break;
            case "Rainy":
                fishManager.fishPrefabs = rainyFish;
                fishManager.fishPerSecond = 5f;
                break;
        }
    }
}
