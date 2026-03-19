using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FishBase : MonoBehaviour
{
    public int size;
    public float speed;
    public bool moveRight;

    private float _value;
    private float _speed;
    public float strength;
    public bool isHooked = false;
    private bool _isFacingRight = true;
    private const float ScreenBorder = 11f;
    private const float ScaleValueMultiplier = 0.05f;//How big the fish is based on its value

    protected FishingSystem _gameSystem;

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
        if (isHooked) return;
        if (_isFacingRight)
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.right);
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.left);
        }

        if (math.abs(transform.position.x) > ScreenBorder)
        {
            Destroy(gameObject);
        }

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            _gameSystem.KillFish();
            Destroy(gameObject);
        }
    }
}
