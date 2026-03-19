using System;
using UnityEngine;

public class BiomeManager : MonoBehaviour
{
    private void Start()
    {
        SetBiome(GameManager.instance.biome);
    }

    void SetBiome(string biome)
    {
        if (biome == "Clear")
        {
            
        }
        
    }
}
