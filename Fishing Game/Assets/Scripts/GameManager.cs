using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private FishManager fishScene;
    public UpgradeInventoryPanel inventoryPanel;
    private float money;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(money);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.TogglePanel();
        }
        if (!Input.GetKeyDown(KeyCode.P))
        {
            money = 0f;
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

    public void CollectMoney(float value)
    {
        money += value;
    }

    public void LoseMoney(float value)
    {
        money -= value;
    }

    public float GetMoney()
    {
        return money;
    }

    public void AddExtraLife()
    {
        if (fishScene != null)
        {
            fishScene.AddLife();
        }
    }

    public int GetLives()
    {
        return fishScene.GetLives();
    }
}
