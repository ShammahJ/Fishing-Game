using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private Collider2D hitbox;
    [SerializeField] private float minStrength;
    [SerializeField] private float maxStrength;
    private float _value;
    private float _speed;
    public float strength;
    public bool isHooked = false;
    private bool _isFacingRight = true;
    private const float ScreenBorder = 11f;
    private const float ScaleValueMultiplier = 0.05f;//How big the fish is based on its value

    public float GetValue()
    {
        return UpgradeManager.Instance.ModifyFishValue(_value);
    }

    //On the fish getting hooked
    public void Hook()
    {
        hitbox.enabled = false;
        isHooked = true;
    }
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.color = Random.ColorHSV();
        _speed = Random.Range(minSpeed, maxSpeed);
        _value = Random.Range(minValue, maxValue);
        strength = Random.Range(minStrength, maxStrength);
        
        transform.localScale = new Vector3(2 + _value * ScaleValueMultiplier, 1 + _value * ScaleValueMultiplier, 1 + _value * ScaleValueMultiplier);

        if (Random.Range(0, 2) == 1) {
            _isFacingRight = true;
            transform.position = new Vector3(-ScreenBorder,Random.Range(minHeight, maxHeight),0);
        }
        else {
            _isFacingRight = false;
            transform.position = new Vector3(ScreenBorder,Random.Range(minHeight, maxHeight),0);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isHooked) return;
        if (_isFacingRight) {
            transform.Translate( _speed * Time.deltaTime * Vector3.right);
        } else {
            transform.Translate( _speed * Time.deltaTime * Vector3.left);
        }
        
        if (math.abs(transform.position.x) > ScreenBorder) {
            Destroy(gameObject);
        }
    }
}
