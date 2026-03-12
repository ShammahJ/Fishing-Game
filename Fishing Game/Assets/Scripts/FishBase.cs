using UnityEngine;

public class FishBase : MonoBehaviour
{
    public int size;
    public float speed;
    public bool moveRight;

    private FishingSystem _gameSystem;

    public void Initialize(bool fromLeft, FishIdentity fishData, FishingSystem system)
    {
        moveRight = fromLeft;
        _gameSystem = system;


        Vector3 fishSize = transform.localScale;
        fishSize.x = size;
        fishSize.y = size;
        fishSize.z = size;
        transform.localScale = fishSize;


        // Debug.Log("This code ran");
        if (!fromLeft)
        {
            // Flip sprite if spawning from right
            // Flip the existing prefab scale
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        FishMove();
        SpecialBehaviour();
        // Debug.Log("Base update is running");
    }

    protected virtual void SpecialBehaviour()
    {
        // Not abstract because not every fish has to have a special behaviour
        // Any child can change this
    }

    protected virtual void FishMove()
    {
        // Spawns moving to the right by default
        // If the fish spawns default, move right
        // If not, move left
        float direction = moveRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            _gameSystem.KillFish();
            Destroy(gameObject);
        }
    }
}
