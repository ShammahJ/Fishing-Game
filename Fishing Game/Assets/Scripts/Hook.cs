using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Hook : MonoBehaviour
{
   
    [SerializeField] private float mouseSpeed = 15;//How fast the hook follows the mouse(X axis)
    [SerializeField] private float speed = 15;//How fast the hook descends(Y axis)
    [SerializeField] private float fishCountMultiplier = 0.05f;//How fast the hook descends(Y axis)
    [SerializeField] private InputAction castAction;

    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI newScoreText;
    
    private HookCollision _hookCollision;
    
    private const float MaxHeight = 4.5f; //applies on both the surface and the bottom of the screen
    private const float MaxDepth = -4.5f;
    private const float MaxWidth = 9.5f;
    private const float DeadZone = 6.5f;

    private float _height;
    private bool _descending = true;
    private bool _active = false;
    private float _currentX;
    private float totalScore;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        castAction.Enable();
    }

    private void OnDisable()
    {
        castAction.Disable();
    }

    void Awake()
    {
        _hookCollision = GetComponent<HookCollision>();
    }
    void Start()
    {
        _height = MaxHeight;
        
    }


    void CastLine()
    {
        if (_active) {
            return;
        }
        _active = true;
        _descending = true;
        newScoreText.text = "";
    }

    
    // Update is called once per frame
    void FixedUpdate()
    { 
        MoveHook();
        CheckDeadZone();
    }

    void Update()
    {
        if (castAction.IsPressed()) {
            CastLine();
        }
    }

    void CheckDeadZone()
    {
        
    }

    void CollectFish()
    {
        
        List<Fish> fishCollected = _hookCollision.CollectFish();
        float value = 0;
        float fishCount = fishCollected.Count;
        
        foreach (var fish in fishCollected) {
            value += fish.GetValue();
            Destroy(fish.gameObject);
        }
        
        float totalValue = value * (fishCountMultiplier * (fishCount + 1f));

        totalScore += totalValue;
        totalScoreText.text = "Score: " + totalScore.ToString("F");
        newScoreText.text = fishCount + " Fish collected, " + totalValue.ToString("F") + " total value!";
    }
    void DescendHook()
    {
        if (!_active) {
            return;
        }
        if (_descending) {
            _height -= Time.deltaTime * speed;
        } else {
            _height += Time.deltaTime * speed;
        }
        if (_height <= MaxDepth) {
            _descending = false;
        } else if (!_descending && _height >= MaxHeight) {
            _height = MaxHeight;
            _active = false;
            CollectFish();
        }
    }
    void MoveHook()
    {
        DescendHook();
        float mouseXPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        
        if (_active) {
            mouseXPos = Mathf.Clamp(mouseXPos, -MaxWidth, MaxWidth);
        }
        else {
            mouseXPos = Mathf.Clamp(mouseXPos, -DeadZone, DeadZone);
        }
      
        _currentX = math.lerp(_currentX, mouseXPos, Time.deltaTime * mouseSpeed);
        transform.position = new Vector3(_currentX, _height, transform.position.z);
    }
}
