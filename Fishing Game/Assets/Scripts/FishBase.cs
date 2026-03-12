using UnityEngine;

public class FishBase : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    private FishingSystem _gameSystem;

    public virtual void Initialize(bool fromLeft, FishIdentity fishData, FishingSystem system)
    {
        moveRight = fromLeft;
        _gameSystem = system;
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

        //if (Mathf.Abs(transform.position.x) > 12.5f)
        //{
        //    _gameSystem.KillFish();
        //    Destroy(gameObject);
        //}
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
