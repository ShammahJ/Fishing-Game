using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Hook : MonoBehaviour
{
   
    [SerializeField] private float mouseSpeed = 15;//How fast the hook follows the mouse(X axis)
    [SerializeField] private float speed = 15;//How fast the hook descends(Y axis)
    [SerializeField] private float fishCountMultiplier = 0.05f;//How fast the hook descends(Y axis)
    // [SerializeField] float mouseSensitivity = 0.5f;
    [SerializeField] private InputAction castAction;

    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private TextMeshProUGUI newScoreText;
    [SerializeReference] float chanceToSwitchStruggleDirection;
    
    private HookCollision _hookCollision;
    
    private const float MaxHeight = 4.5f; //applies on both the surface and the bottom of the screen
    private const float MaxDepth = -4.5f;
    private const float MaxWidth = 9.5f;
    private const float DeadZone = 7f;
    private float _height;
    private bool _descending = true;
    private bool _active;
    private float _currentX;
    private float _totalScore;
    public List<Fish> fishes;

    private float _currentStrength;
    private bool _strugglingRight;
    

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
        _hookCollision.onHook.AddListener(OnHook);
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

    void OnHook(Fish fish)
    {
        fishes.Add(fish);
        _currentStrength += fish.strength;
    }

    void CollectFish()
    {
        float value = 0;
        float fishCount = fishes.Count;
        
        foreach (var fish in fishes) {
            value += fish.GetValue();
            Destroy(fish.gameObject);
        }
        fishes.Clear();
        _currentStrength = 0;
        
        float totalValue = value * (fishCountMultiplier * (fishCount + 1f));

        _totalScore += totalValue;
        totalScoreText.text = "Score: " + _totalScore.ToString("F");
        newScoreText.text = fishCount + " Fish collected, " + totalValue.ToString("F") + " total value!";
    }

    void BreakHook()
    {
        foreach (var fish in fishes) {
            Destroy(fish.gameObject);
        }
        fishes.Clear();
        _currentStrength = 0;
        _active = false; 
        _descending = true;
        _height = MaxHeight;
        transform.position = new Vector3(_currentX, _height, transform.position.z);
        // totalScoreText.text = "Score: " + totalScore.ToString("F");
        newScoreText.text = "Your line broke!";
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
        float struggle;
      
        if (Random.Range(0f, 1f) <= chanceToSwitchStruggleDirection) {
            _strugglingRight = !_strugglingRight;
        }

        if (_strugglingRight) {
            struggle = Random.Range(_currentStrength * 0.2f, _currentStrength);
        }
        else {
            struggle = Random.Range(-_currentStrength * 0.2f, -_currentStrength); 
        }
        
        // float mouseDelta = Input.mousePositionDelta.x * mouseSensitivity;    
        if (_active) {
            mouseXPos = Mathf.Clamp(mouseXPos, -MaxWidth, MaxWidth);
           
        }
        else {
            mouseXPos = Mathf.Clamp(mouseXPos, -DeadZone, DeadZone);
        }
        float goalX = mouseXPos + struggle;
        
      
        // float goalX = _currentX + mouseDelta + struggle;
        if (_active) {
            goalX = Mathf.Clamp(goalX, -MaxWidth, MaxWidth);
            // Mouse.current.WarpCursorPosition(transform.position * new Vector2(Screen.width/2, Screen.height/2));
            Mouse.current.WarpCursorPosition(Mouse.current.position.ReadValue() + new Vector2(struggle,0)); //This gets messed up depending on screen size, please fix!
            if (Mathf.Abs(_currentX) > DeadZone) {
                BreakHook();
            }
        }
        else {
            goalX = Mathf.Clamp(goalX, -DeadZone, DeadZone);
        }
        
        _currentX = math.lerp(_currentX, goalX, Time.deltaTime * mouseSpeed);
        transform.position = new Vector3(_currentX, _height, transform.position.z);
    }
}
