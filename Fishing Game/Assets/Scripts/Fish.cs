using UnityEngine;


public class Fish : MonoBehaviour
{
    // Fish rigidbody
    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
