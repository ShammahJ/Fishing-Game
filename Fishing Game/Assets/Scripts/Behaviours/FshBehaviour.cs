using UnityEngine;

public class FshBehaviour : FishBase
{
    public float minAmplitude;
    public float maxAmplitude;
    private float amplitude;

    public float minFrequency;
    public float maxFrequency;
    private float frequency;

    //public override void Initialize(bool fromLeft, FishIdentity fishData, FishingSystem system)
    //{
    //    base.Initialize(fromLeft, fishData, system);

    //    amplitude = Random.Range(minAmplitude, maxAmplitude);
    //    frequency = Random.Range(minFrequency, maxFrequency);
    //}
    private void Start()
    {
        amplitude = Random.Range(minAmplitude, maxAmplitude);
        frequency = Random.Range(minFrequency, maxFrequency);

    }

    protected override void FishMove()
    {
        float direction = moveRight ? 1f : -1f;

        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.Translate(new Vector2(direction * speed * Time.deltaTime, yOffset * Time.deltaTime));

        Debug.Log("No eyes' special movement is being called");
    }
}
