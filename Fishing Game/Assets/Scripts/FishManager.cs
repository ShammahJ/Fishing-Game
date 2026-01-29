using UnityEditor;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] [Range(0.05f,25f)] private float fishPerSecond = 1f;
    // private GameObject[] fishes;
    private float _fishTimer = 0;
    
    void Start()
    {
        _fishTimer = 1f / fishPerSecond;
    }

    void SpawnFish()
    {
        // GameObject fish = Instantiate(fishPrefab);
        Instantiate(fishPrefab);
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
