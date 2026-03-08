using System;
using UnityEditor;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] FishManager _fishManager;
    [SerializeField] GameObject livesPrefab;

    public void OnLivesChange(int lives)
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        int currentLives = children.Length - 1;
        if (lives > currentLives) {
            for (int i = currentLives; i < lives; i++) {
                GameObject life = Instantiate(livesPrefab, transform);
                life.name = i.ToString();
            }
        }
        else if (lives < children.Length) {
            foreach (Transform child in children) {
                int childInt;
                Int32.TryParse(child.name, out childInt);
                if (childInt >= lives)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        
    }
}
