using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingSystem : MonoBehaviour
{
    public Transform[] _commonSpawns;
    public Transform[] _rareSpawns;
    public Transform[] _epicSpawns;
    public Transform[] _legendarySpawns;
    public FishIdentity[] possibleCatches;

    // Codes I reused from class

    public int _currentFishCount = 0;

    // Max number of fishes to spawn
    public int _desiredFishes = 5;

    // Speed of fishes spawning
    public float _spawnRate = 2.0f;

    // Time since last spawn
    private float _timeSinceLastSpawn = 0.0f;
    // Can spawn
    private bool _canSpawn = true;

    // Directuon of the fis
    private bool _spawnFromLeft;

    private void Start()
    {
        Fish();
    }
    public void Fish()
    {
        FishIdentity result = GetRandomCatch();

        if (result == null || result.isNothing)
            return;

        Debug.Log(result.objectName);

        SpawnFish(result);
    }

    // Decides what fish to spawn
    FishIdentity GetRandomCatch()
    {
        // Sets the current weight to 0, 
        float totalWeight = 0;

        // Checks each fish'es weight and adds it to the total weight
        foreach (FishIdentity currentFish in possibleCatches)
        {
            totalWeight += 1f / currentFish.weight;
        }

        float randomWeight = Random.Range(0, totalWeight);
        FishIdentity selectedFish = null;
        float cumulativeWeight = 0;

        foreach (FishIdentity currentFish in possibleCatches)
        {
            /// /summary
            /// 1 out of weight chance
            /// The bigger the weight, the lower the chance
            /// /*summary
            cumulativeWeight += 1f / currentFish.weight;

            if (randomWeight <= cumulativeWeight)
            {
                selectedFish = currentFish;
                // Debug.Log("Code Ran");
                break;
            }
        }
        return selectedFish;
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= _spawnRate && _currentFishCount < _desiredFishes)
        {
            Fish();
            _timeSinceLastSpawn = 0f;
            _currentFishCount++;
        }
    }

    public void SpawnFish(FishIdentity result)
    {
        // Checks what the chosen fish's rarity and return an array of spawnpoints
        Transform[] _spawns = GetSpawnpoint(result.rarity);

        // Just in case...

        if (_spawns == null || _spawns.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned for rarity: " + result.rarity);
            return;
        }

        // Pick random spawn from that rarity pool
        Transform _spawnPoint = _spawns[Random.Range(0, _spawns.Length)];

        // Determine direction based on spawn position
        if (_spawnPoint.position.x <= 0)
            _spawnFromLeft = true;
        if (_spawnPoint.position.x > 0)
            _spawnFromLeft = false;


            GameObject fishObj = Instantiate(result.fishPrefab, _spawnPoint.position, Quaternion.identity);


        FishMove mover = fishObj.GetComponent<FishMove>();
        mover.speed = result.baseSpeed;
        mover.Initialize(_spawnFromLeft, result, this);

        

        
    }

    public Transform[] GetSpawnpoint(FishRarity rarity)
    {
        switch (rarity)
        {
            case FishRarity.Common:
                return _commonSpawns;

            case FishRarity.Rare:
                return _rareSpawns;

            case FishRarity.Epic:
                return _epicSpawns;

            case FishRarity.Legendary:
                return _legendarySpawns;
        }

        return null;
    }

    public void KillFish()
    {
        _currentFishCount--;
    }
}
