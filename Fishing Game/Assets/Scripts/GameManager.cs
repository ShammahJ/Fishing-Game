using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {
    
    public UnityEvent<int> livesChanged;
    private const int LivesMax = 5;
    public int lives = 0;

    [SerializeField] private Hook hook;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hook.onCollect.AddListener(OnCollect);
        hook.onBreak.AddListener(OnCollect);
        StartFishingGame();
    }

    void OnCollect(float value)
    {
        OnCollect();
    }
    
    void OnCollect()
    {
        lives--;
        livesChanged.Invoke(lives);
        if (lives == 0) {
            EndFishingGame();
        }
            
    }

    void StartFishingGame()
    {
        lives = 3;
    }
    
    void EndFishingGame()
    {
        lives = 3;
    }
}
