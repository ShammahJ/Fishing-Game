using UnityEngine;

public class FshBehaviour : FishBase
{
    public float minAmplitude;
    public float maxAmplitude;
    public float amplitude;

    public float minFrequency;
    public float maxFrequency;
    public float frequency;

    public override void Initialize(bool fromLeft, FishIdentity fishData, FishingSystem system)
    {
        base.Initialize(fromLeft, fishData, system);

        amplitude = Random.Range(minAmplitude, maxAmplitude);
        frequency = Random.Range(minFrequency, maxFrequency);
    }
    protected override void FishMove()
    {
        float direction = moveRight ? 1f : -1f;

        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.Translate(new Vector2(direction * speed * Time.deltaTime, yOffset * Time.deltaTime));
    }
}
