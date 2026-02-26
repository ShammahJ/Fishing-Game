using UnityEngine;

public class SineBubble : MonoBehaviour {
    [SerializeField] private Vector2 sineAmount;
    [SerializeField] private Vector2 sineSpeed;
    private Vector2 _startPosition;
    // private Quaternion _startRotation;
    private float _tick;
    void Start()
    {
        _tick = Random.Range(-10f, 10f);
        print(_tick);
        _startPosition =  transform.position;
        // _startRotation = transform.rotation;
        // transform.rotation =  transform.rotation
    }

    void Update()
    {
        _tick += Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(_tick * sineSpeed.x) * sineAmount.x, Mathf.Sin(_tick * sineSpeed.y) * sineAmount.y);
        transform.position = _startPosition + offset;
        // transform.rotation = _startRotation;
    }
}
