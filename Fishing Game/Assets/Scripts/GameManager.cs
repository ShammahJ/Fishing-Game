using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public UnityEvent<float> onMoneyChanged;
    [SerializeField] private FishManager fishScene;
    public UpgradeInventoryPanel inventoryPanel;
    public float money;

    public float debt;
    private const float StartingDebt = 25f;
    private const float ScalingDebt = 15f;
    public int level = -1;
    

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

    void Update()
    {
        //Please delete this once you're done.
        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     SceneManager.LoadScene("Shop");
        // }
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     Debug.Log(money);
        // }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.TogglePanel();
        }
        // if (!Input.GetKeyDown(KeyCode.P))
        // {
        //     money = 0f;
        // }
    }

    public void LevelIncrease()
    {
        level++;
        debt = StartingDebt + ScalingDebt * level;
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
