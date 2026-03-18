using UnityEngine;

// Object must have a component of type AudioSource
[RequireComponent(typeof(AudioSource))]
public class ClownfishBehaviour : Fish
{
    // I'm not comfortable with coroutines, so I'm using this instead
    public float minPauseTime = 2f;
    public float maxPauseTime = 5f;

    public AudioClip sound;

    private float timer;
    private bool paused;
    private int honked;
    private AudioSource audioSource;

    // Save the original speed for when the fish moves again
    private float ogSpeed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = Random.Range(minPauseTime, maxPauseTime);
        ogSpeed = _speed;
    }

    protected override void SpecialBehaviour()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && honked < 2)
        {
            paused = !paused;

            if (paused)
            {
                speed = 0;

                if (sound != null)
                    audioSource.PlayOneShot(sound);
            }
            else
            {
                speed = ogSpeed;
            }

            timer = Random.Range(minPauseTime, maxPauseTime);
            honked++;
        }
    }
}
