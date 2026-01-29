using System.Collections;
using UnityEngine;

public class HookCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int _fishCount;
    private float _collectedValue;
    public ArrayList CollectFish()
    {
        ArrayList arr = new ArrayList();
        arr.Add(_fishCount);
        arr.Add(_collectedValue);
        _fishCount = 0;
        _collectedValue = 0;
        return arr;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Fish")) {return;}
        Fish collectedFish = collision.gameObject.GetComponent<Fish>();
        _collectedValue += collectedFish.GetValue();
        _fishCount += 1;
        Destroy(collision.gameObject);
    }
}
