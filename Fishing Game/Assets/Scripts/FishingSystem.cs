using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    public FishIdentity[] possibleCatches;

    // Codes I reused from class

    // Max number of fishes to spawn
    public int _desiredFishes = 5;

    // Speed of fishes spawning
    public float _spawnRate = 2.0f;

    // Time since last spawn
    private float _timeSinceLastSpawn = 0.0f;
    // Can spawn
    private bool _canSpawn = true;

    private void Start()
    {
        Fish();
    }
    public void Fish()
    {
        FishIdentity result = GetRandomCatch();
        Debug.Log(GetRandomCatch().objectName);
    }

    
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fish();
        }
    }
}
