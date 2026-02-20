using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    public Fish[] possibleCatches;

    private void Start()
    {
        Fish();
    }
    public void Fish()
    {
        Fish result = GetRandomCatch();
        Debug.Log(GetRandomCatch().objectName);
    }

    
    Fish GetRandomCatch()
    {
        // Sets the current weight to 0, 
        float totalWeight = 0;

        // Checks each fish'es weight and adds it to the total weight
        foreach (Fish currentFish in possibleCatches)
        {
            totalWeight += 1f / currentFish.weight;
        }

        float randomWeight = Random.Range(0, totalWeight);
        Fish selectedFish = null;
        float cumulativeWeight = 0;

        foreach (Fish currentFish in possibleCatches)
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
