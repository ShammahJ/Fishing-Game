using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WeightedFish
{
    public GameObject prefab;
    public float weight = 1f; // Bigger = more common
}

public class FishManager : MonoBehaviour
{
    [Header("Fish Spawning")]
    [SerializeField] private List<WeightedFish> fishPrefabs;
    [SerializeField] [Range(0.05f, 25f)] private float fishPerSecond = 1f;
    // private GameObject[] fishes;
    private float _fishTimer;
    private int _currentFishCount;

    [Header("Lives")]
    public UnityEvent<int> livesChanged;
    public UnityEvent outOfLives;

    private const int LivesMax = 5;
    private int _lives;

    void OnEnable()
    {
        _lives = LivesMax;
        livesChanged.Invoke(_lives);
    }

    public void OnCollect(float value)
    {
        //for now empty
        OnCollect();
    }

    void OnCollect()
    {
        _lives--;
        livesChanged.Invoke(_lives);
        print(_lives);
        if (_lives <= 0)
        {
            outOfLives.Invoke();
        }
    }

    public int GetLives()
    {
        return _lives;
    }

    public void AddLife()
    {
        _lives++;
        livesChanged.Invoke(_lives);
    }

    public void KillFish()
    {
        _currentFishCount--;
    }

    void Start()
    {
        _fishTimer = 1f / fishPerSecond;
    }

    //WEIGHTED RANDOM SYSTEM
    GameObject GetRandomFish()
    {
        float totalWeight = 0f;

        foreach (var fish in fishPrefabs)
        {
            totalWeight += 1f / fish.weight;
        }

        float random = Random.Range(0, totalWeight);
        GameObject selectedFish = null;
        float cumulative = 0f;

        foreach (var fish in fishPrefabs)
        {
            cumulative += 1f / fish.weight;

            if (random <= cumulative)
            {
                selectedFish = fish.prefab;
            }
        }

        return selectedFish;
    }

    void SpawnFish()
    {
        GameObject prefab = GetRandomFish();

        if (prefab == null) return;

        Instantiate(prefab, transform);

        // Allows the fish to access the methods in here
        //Fish fbase = prefab.GetComponent<Fish>();
        //fbase.Initialize(this);
    }

    void Update()
    {
        _fishTimer -= Time.deltaTime;

        if (_fishTimer > 0) return;

        _fishTimer += 1f / fishPerSecond;
        SpawnFish();
    }
}