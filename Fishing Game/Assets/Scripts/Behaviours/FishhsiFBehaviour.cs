using UnityEngine;

public class FishhsiFBehaviour : Fish
{
    public float minTurnTime = 2f;
    public float maxTurnTime = 4f;

    private float timer;
    private int turns = 0;
    private float turnLimit;

    protected override void Start()
    {
        base.Start();
        ResetTimer();
        turnLimit = Random.Range(3, 6);
    }

    protected override void SpecialBehaviour()
    {
        //Debug.Log("Special Condition being called");
        
        timer -= Time.deltaTime;
        if (timer <= 0 && turns != turnLimit)
        {
            _isFacingRight = !_isFacingRight;
            ResetTimer();
            turns++;
        }
    }

    void ResetTimer()
    {
        timer = Random.Range(minTurnTime, maxTurnTime);
    }
}
