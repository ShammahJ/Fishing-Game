using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {

    [SerializeField] private FishManager fishScene;

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartFishingGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Shop");
        }
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
