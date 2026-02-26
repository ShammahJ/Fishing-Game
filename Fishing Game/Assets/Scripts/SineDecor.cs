using UnityEngine;

public class SineDecor : MonoBehaviour {
    [SerializeField] private Vector2 sinePositionAmount;
    [SerializeField] private float sineRotationAmount;
    [SerializeField] private Vector2 sineSpeed;
    private Vector2 _startPosition;
    private Quaternion _startRotation;
    private float _tick;
    void Start()
    {
        _tick = Random.Range(-10f, 10f);
        _startPosition =  transform.position;
        _startRotation = transform.rotation;
    }

    void Update()
    {
        _tick += Time.deltaTime;
        Vector2 posOffset = new Vector2(Mathf.Sin(_tick * sineSpeed.x) * sinePositionAmount.x, Mathf.Sin(_tick * sineSpeed.y) * sinePositionAmount.y);
        Vector3 rotOffset = new Vector3(0,0,Mathf.Sin(_tick * sineSpeed.x) * sineRotationAmount);
        transform.position = _startPosition + posOffset;
        transform.rotation = Quaternion.Euler(_startRotation.eulerAngles + rotOffset);
    }
}
