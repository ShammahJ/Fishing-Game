using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 3f;
    private bool moveRight;

    public void Initialize(bool fromLeft, FishIdentity fishData)
    {
        moveRight = fromLeft;

        if (!fromLeft)
        {
            // Flip sprite if spawning from right
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    

    
    void Update()
    {
        // Spawns moving to the right by default
        // If the fish spawns default, move right
        // If not, move left
        float direction = moveRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
}
