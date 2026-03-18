using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public static FishManager instance;
    
    private int _lives;
    void Start()
    {
        _lives = LivesMax;
        livesChanged.Invoke(_lives);
        
        _fishTimer = 1f / fishPerSecond;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
            instance = this;
        }

        GameManager.instance.LevelIncrease();
    }
    
    public void OnCollect(float moneyGained)
    {
        GameManager.instance.CollectMoney(moneyGained);
        _lives--;
        livesChanged.Invoke(_lives);
        if (_lives <= 0) {
            // GameManager.instance.CollectMoney(score * scoreToMoneyMulti);
            SceneManager.LoadScene("Map");
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
                break;
                
            }
        }

        return selectedFish;
    }

    void SpawnFish()
    {
        Debug.Log("Trying to spawn fish");

        GameObject prefab = GetRandomFish();

        if (prefab == null)
        {
            Debug.LogWarning("No fish selected!");
            return;
        }

        // Make the fish
        GameObject fishObj = Instantiate(prefab, transform);
        Debug.Log(prefab.name);

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