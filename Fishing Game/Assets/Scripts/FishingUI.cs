using TMPro;
using UnityEngine;

public class FishingUI : MonoBehaviour
{
    
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    [SerializeField] private FishManager fishManager;
    public void UpdateScore(float score)
    {
        print("We did it!");
        scoreText.text = score.ToString();
    }

    public void UpdateMoney(float money)
    {
        print("We did it!");
        moneyText.text = money.ToString();
    }
}
