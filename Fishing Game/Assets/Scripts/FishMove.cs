using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 3f;
    public bool moveRight;

    private FishingSystem _gameSystem;

    public void Initialize(bool fromLeft, FishIdentity fishData, FishingSystem system)
    {
        moveRight = fromLeft;
        _gameSystem = system;
        Debug.Log("This code ran");
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

        if (Mathf.Abs(transform.position.x) > 12.5f)
        {
            _gameSystem.KillFish();
            Destroy(gameObject);
        }
    }
}
