using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Stats")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minStrength;
    [SerializeField] private float maxStrength;

    [Header("Other Things")]
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private bool isRandomColor;

    public float _value;
    protected float _speed;
    public float strength;

    protected FishManager _gameSystem;
    public bool isHooked = false;
    protected bool _isFacingRight = true;

    private const float ScreenBorder = 11f;
    private const float ScaleValueMultiplier = 0.05f;//How big the fish is based on its value

    protected virtual void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Random Colour (Catfish)
        if (isRandomColor)
        {
            spriteRenderer.color = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
        }

        // Random Stats
        _speed = Random.Range(minSpeed, maxSpeed);
        _value = Random.Range(minValue, maxValue);
        strength = Random.Range(minStrength, maxStrength);

        // Scale Size base on value
        transform.localScale = new Vector3(1 + _value * ScaleValueMultiplier, 1 + _value * ScaleValueMultiplier, 1 + _value * ScaleValueMultiplier);

        if (Random.Range(0, 2) == 1)
        {
            _isFacingRight = true;
            transform.position = new Vector3(-ScreenBorder, Random.Range(minHeight, maxHeight), 0);
        }
        else
        {
            _isFacingRight = false;
            spriteRenderer.flipX = true;
            transform.position = new Vector3(ScreenBorder, Random.Range(minHeight, maxHeight), 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        FishMove();
        SpecialBehaviour();
    }

    public void Initialize(FishManager system)
    {
        _gameSystem = system;
    }

    protected virtual void FishMove()
    {
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
            Debug.Log("Destroyed " + this.name);
        }
    }

    protected virtual void SpecialBehaviour()
    {
        // Override in child classes
        // Not abstract since it's not required for child classes to have a special behaviour
    }

    public float GetValue()
    {
        return UpgradeManager.Instance.ModifyFishValue(_value, this);
    }

    public float GetOriginalValue()
    {
        return _value;
    }

    //On the fish getting hooked
    public void Hook()
    {
        hitbox.enabled = false;
        isHooked = true;
    }
}
