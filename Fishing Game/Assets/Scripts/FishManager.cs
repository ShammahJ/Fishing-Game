using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FishManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> fishPrefabs;
    [SerializeField] [Range(0.05f,25f)] private float fishPerSecond = 1f;
    // private GameObject[] fishes;
    private float _fishTimer;
    
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

    void SpawnFish()
    {
        // GameObject fish = Instantiate(fishPrefab);
        int index = Random.Range(0, fishPrefabs.Count);
        GameObject fishPrefab = fishPrefabs[index];
        Instantiate(fishPrefab,transform);
    }

    // Update is called once per frame
    void Update()
    {
        _fishTimer -= Time.deltaTime;
        if (_fishTimer > 0) {return;}
        _fishTimer += 1f / fishPerSecond; 
        SpawnFish();
    }
    
}
