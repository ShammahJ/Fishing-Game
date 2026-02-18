using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HookCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private List<Fish> _fishes = new List<Fish>();
    private float _collectedValue;
    public List<Fish> CollectFish()
    {
        return _fishes;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Fish")) {return;}
        Fish collectedFish = collision.gameObject.GetComponent<Fish>();
        _fishes.Add(collectedFish);
        collectedFish.Hook();
        // Destroy(collision.gameObject);
    }
}
