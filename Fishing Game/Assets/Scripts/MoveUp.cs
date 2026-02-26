using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}

