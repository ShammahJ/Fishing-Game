using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> fishPrefabs;
    [SerializeField] [Range(0.05f,25f)] private float fishPerSecond = 1f;
    // private GameObject[] fishes;
    private float _fishTimer;
    
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
        if (_lives <= 0) {
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

    void Start()
    {
        _fishTimer = 1f / fishPerSecond;
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
