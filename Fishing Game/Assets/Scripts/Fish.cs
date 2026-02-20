using UnityEngine;


public class Fish : MonoBehaviour
{
    // Fish rigidbody
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
