using UnityEngine;

public class DestroyOutOfBounds : BubbleSpawner
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
            BubbleSpawner.TotalBubbles--;
        }
        else if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
            BubbleSpawner.TotalBubbles--;
        }


    }
}
