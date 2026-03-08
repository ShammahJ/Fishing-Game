using System;
using UnityEditor;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject livesPrefab;
    private void Awake()
    {
        _gameManager.livesChanged.AddListener(OnLivesChange);
        OnLivesChange(3);
    }

    private void OnLivesChange(int lives)
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children) {
            print(child);
        }

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
