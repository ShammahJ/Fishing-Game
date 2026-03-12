using UnityEngine;

public class FshBehaviour : FishBase
{
    public float amplitude = 1f;
    public float frequency = 2f;

    protected override void FishMove()
    {
        float direction = moveRight ? 1f : -1f;

        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.Translate(new Vector2(direction * speed * Time.deltaTime, yOffset * Time.deltaTime));
    }
}
