using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class DifficultyChanges {
    public float StartingDebt;
    public float ScalingDebt;
}
public class GameManager : MonoBehaviour {


    public Dictionary<string, bool> tutorialSeen =  new Dictionary<string, bool>();
    public UnityEvent<float> onMoneyChanged;
    [SerializeField] private FishManager fishScene;
    [System.NonSerialized] public UpgradeInventoryPanel inventoryPanel;
    public float money;

    public float debt;

    private DifficultyChanges[] difficultyValues = new DifficultyChanges[3];
    public int difficulty = 1;
    
    public int level = -1;

    public string biome = "Clear";
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
        DifficultyChanges easyDifficulty = new DifficultyChanges();
        easyDifficulty.StartingDebt = 75f;
        easyDifficulty.ScalingDebt = 25f;
        
        DifficultyChanges normalDifficulty = new DifficultyChanges();
        normalDifficulty.StartingDebt = 150;
        normalDifficulty.ScalingDebt = 50f;
        
        DifficultyChanges hardDifficulty = new DifficultyChanges();
        hardDifficulty.StartingDebt = 250f;
        hardDifficulty.ScalingDebt = 75f;

        difficultyValues[0] = easyDifficulty;
        difficultyValues[1] = normalDifficulty;
        difficultyValues[2] = hardDifficulty;
    }

    public void SetDifficulty(int diff)
    {
        difficulty = diff;
    }

    void Update()
    {
        if (inventoryPanel == null)
        {
            inventoryPanel = FindObjectOfType<UpgradeInventoryPanel>(true);
        }

        if (inventoryPanel != null && Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.TogglePanel();
        }
    }

    public void LevelIncrease()
    {
        level++;
        debt = difficultyValues[difficulty].StartingDebt + difficultyValues[difficulty].ScalingDebt * level;
    }

    public void CheckLossState()
    {
        if (money < debt) {
            SceneManager.LoadScene("LossScreen");
            return;
        }
        //LoseMoney(debt);

        if (MapGameManager.onRain2 && MapGameManager.hasFinishedRain2)
        {
            SceneManager.LoadScene("WinScreen");
            AddLeaderboardEntry();
        }
        else
        {
            //SceneManager.LoadScene("Map");
            SceneManager.LoadScene("AdjustDebt");
        }
    }

    public void ResetGame()
    {
        level = -1;
        money = 0;
        difficulty = 1;
        debt = difficultyValues[difficulty].StartingDebt;
        tutorialSeen.Clear();
        MapGameManager.Reset();
        UpgradeManager.Instance.activeUpgrades.Clear();
    }

    public void CollectMoney(float value)
    {
        money += value;
        onMoneyChanged.Invoke(money);
    }

    public void LoseMoney(float value)
    {
        money -= value;
        onMoneyChanged.Invoke(money);
    }

    public float GetMoney()
    {
        return money;
    }

    public int GetLives()
    {
        return fishScene.GetLives();
    }

    public void AddLeaderboardEntry()
    {
        if (LeaderboardManager.Instance != null)
        {
            bool isHighScore = LeaderboardManager.Instance.IsHighScore(money, difficulty);

            if (isHighScore)
            {
                LeaderboardUI leaderboardUI = FindObjectOfType<LeaderboardUI>(true);
                if (leaderboardUI != null)
                {
                    leaderboardUI.ShowNewScoreEntry(money, difficulty);
                }
            }
        }
    }
}
