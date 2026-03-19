using System;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI moneyText;
    void Start()
    {
        UpdateMoney(GameManager.instance.money);
    }
    public void UpdateMoney(float money)
    {
        string formatedMoney = (Mathf.Round(money * 10f) * 0.1f).ToString();
        formatedMoney = formatedMoney +  "/<color=red>" + (Mathf.Round(GameManager.instance.debt * 10f) * 0.1f).ToString() + "</color>";
        moneyText.text = formatedMoney + "$";
    }
}
