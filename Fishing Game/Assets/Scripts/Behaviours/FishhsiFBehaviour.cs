using UnityEngine;

public class FishhsiFBehaviour : FishBase
{
    public float minTurnTime = 2f;
    public float maxTurnTime = 5f;

    private float timer;
    private int turns = 0;
    private float turnLimit;

    void Start()
    {
        ResetTimer();
        turnLimit = Random.Range(3, 6);
    }

    protected override void SpecialBehaviour()
    {
        Debug.Log("Special Condition being called");
        
        timer -= Time.deltaTime;
        if (timer <= 0 && turns != turnLimit)
        {
            moveRight = !moveRight;
            ResetTimer();
            turns++;
        }
    }

    void ResetTimer()
    {
        timer = Random.Range(minTurnTime, maxTurnTime);
    }
}
