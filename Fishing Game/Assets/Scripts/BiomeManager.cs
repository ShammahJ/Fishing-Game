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
    [SerializeField] private SpriteRenderer background;
    public void SetBiome(string biome)
    {
        seaweed.SetActive(false);
        switch (biome) {
            case "Beach":
                fishManager.fishPrefabs = beachFish;
                fishManager.fishPerSecond = 2f;
                fishManager.livesMax = 5;
                background.color = new Color(1f, 1f, 0.8f);
                break;
            case "Clear":
                fishManager.fishPrefabs = clearFish;
                fishManager.fishPerSecond = 1f;
                fishManager.livesMax = 5;
                background.color = new Color(1f, 1f, 1f);
                break;
            case "Swamp":
                fishManager.fishPrefabs = swampFish;
                fishManager.fishPerSecond = 2.5f;
                fishManager.livesMax = 5;
                background.color = new Color(0.8f, 1, 0.8f);
                seaweed.SetActive(true);
                
                break;
            case "Rain":
                fishManager.fishPrefabs = rainyFish;
                fishManager.fishPerSecond = 4f;
                fishManager.livesMax = 3;
                background.color = new Color(0.2f, 0.5f, 1f);
                break;
        }
    }
}
