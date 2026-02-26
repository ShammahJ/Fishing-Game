using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public Transform _spawnParent;
    public List<GameObject> _bubbleTypes = new List<GameObject>();
    public List<Transform> _spawnPoints = new List<Transform>();
    public int _desiredBubbles = 20;
    public float _spawnRate = 0.2f;
    private float _timeSinceLastSpawn = 0.0f;
    private bool _canSpawn = true;
    public static int _totalBubbles = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateSpawnTimer();
        SpawnDesiredBubbles();
    }
    private void UpdateSpawnTimer()
    {
        if (!_canSpawn)
        {
            if (_timeSinceLastSpawn >= _spawnRate)
            {
                _canSpawn = true;
                _timeSinceLastSpawn = 0f;
            }
            _timeSinceLastSpawn += Time.deltaTime;
        }
    }
    private void SpawnDesiredBubbles()
    {
        if (_totalBubbles < _desiredBubbles)
        {
            if (_canSpawn)
            {
                SpawnRandomBubbles();
                _canSpawn = false;
            }
        }
    }
    private void SpawnRandomBubbles()
    {
        int bubbleType = Random.Range(0, _bubbleTypes.Count);
        int spawnPoint = Random.Range(0, _spawnPoints.Count);
        Instantiate(_bubbleTypes[bubbleType], _spawnPoints[spawnPoint].position, _spawnPoints[spawnPoint].rotation, _spawnParent);
        _totalBubbles++;
    }
}
