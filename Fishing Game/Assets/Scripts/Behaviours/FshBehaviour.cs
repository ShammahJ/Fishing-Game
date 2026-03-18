using UnityEngine;

public class FshBehaviour : Fish
{
    public float minAmplitude;
    public float maxAmplitude;
    private float amplitude;

    public float minFrequency;
    public float maxFrequency;
    private float frequency;

    private void Start()
    {
        amplitude = Random.Range(minAmplitude, maxAmplitude);
        frequency = Random.Range(minFrequency, maxFrequency);


        //Vector3 fishSize = transform.localScale;
        //fishSize.x = size;
        //fishSize.y = size;
        //fishSize.z = size;
    }

    protected override void FishMove()
    {
        float direction = _isFacingRight ? 1f : -1f;

        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.Translate(new Vector2(direction * _speed * Time.deltaTime, yOffset * Time.deltaTime));
    }
}
