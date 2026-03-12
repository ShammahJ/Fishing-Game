using UnityEngine;

public class FishhsiFBehaviour : FishBase
{
    public float minTurnTime = 2f;
    public float maxTurnTime = 5f;

    private float _timer;

    void Start()
    {
        ResetTimer();
    }

    protected override void SpecialBehaviour()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            FishMove();
        }
    }

    void ResetTimer()
    {
        _timer = Random.Range(minTurnTime, maxTurnTime);
    }
    protected override void FishMove()
    {
        moveRight = !moveRight;
        float direction = moveRight ? 1f : -1f;
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        // This Code Ran

        ResetTimer();
    }
}
