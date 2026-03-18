using UnityEngine;
using System.Collections;

// Object must have a component of type AudioSource
[RequireComponent(typeof(AudioSource))]
public class SharkBehaviour : Fish
{
    private float growthAmount = 0.2f;

    public Sprite normal;
    public Sprite eat;

    public AudioClip eatSFX;
    private AudioSource audioSource;

    private SpriteRenderer sr;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

      void OnTriggerEnter2D(Collider2D collision)
    {
        
        FishBase otherFish = collision.GetComponent<FishBase>();

        if (otherFish != null && otherFish != this && collision.CompareTag("Fish"))
        {
            _gameSystem.KillFish();
            Destroy(otherFish.gameObject);

            Grow();

            StartCoroutine(EatFrame());
        }
    }

    private void Grow()
    {
        Vector3 scale = transform.localScale;

        // Preserves the sign of the number (pos/neg)
        // Had an issue where the shark was only growing in height and not width (fixed)
        scale.x += Mathf.Sign(scale.x) * growthAmount;
        scale.y += growthAmount;

        transform.localScale = scale;
    }

    IEnumerator EatFrame()
    {
        sr.sprite = eat;
        audioSource.PlayOneShot(eatSFX);
        yield return new WaitForSeconds(0.5f);

        sr.sprite = normal;
    }
}
