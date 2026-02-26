using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HookCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent<Fish> onHook;
    
  
    private float _collectedValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Fish")) {return;}
        Fish collectedFish = collision.gameObject.GetComponent<Fish>();
        if (collectedFish.isHooked) return;
        onHook.Invoke(collectedFish);
        collectedFish.Hook();
        
       
        // Destroy(collision.gameObject);
    }
}
