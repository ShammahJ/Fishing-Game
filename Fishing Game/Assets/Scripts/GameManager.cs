using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {

    [SerializeField] private FishManager fishScene;

    private void Start()
    {
        StartFishingGame();
    }

    void StartFishingGame()
    {
        print("StartFishingGame");
        fishScene.gameObject.SetActive(true);
    }
    
    public void EndFishingGame()
    {
        print("endFishingGame");
        fishScene.gameObject.SetActive(false);
    }
}
