using UnityEngine;
using System.Collections;

public class LegfishBehaviour : Fish
{
    private float wobbleSpeed;
    private Rigidbody2D rb;
    protected override void Start()
    {
        base.Start();
        if (_speed <= 15)
            wobbleSpeed = 0.7f;
        else if (_speed <= 25 && _speed > 15)
            wobbleSpeed = 0.4f;
        else
            wobbleSpeed = 0.2f;

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Wobble());
    }
    IEnumerator Wobble()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            yield return new WaitForSeconds(wobbleSpeed);

            transform.rotation = Quaternion.Euler(0, 0, -45);
            yield return new WaitForSeconds(wobbleSpeed);
        }
    }
    protected override void FishMove()
    {
        if (isHooked) return;

        // Apply force instead of Translate
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Fish"), LayerMask.NameToLayer("Fish"));

        if (_isFacingRight)
        {
            rb.AddForce(Vector2.right * _speed, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.left * _speed, ForceMode2D.Force);
        }

        // Limit speed
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, _speed);

        if (Mathf.Abs(transform.position.x) > 11f)
        {
            Destroy(gameObject);
        }
    }
}
