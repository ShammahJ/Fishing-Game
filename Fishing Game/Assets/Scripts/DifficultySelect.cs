using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelect : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    void Start()
    { 
        dropdown.value = GameManager.instance.difficulty;
        dropdown.onValueChanged.AddListener(ValueChanged);
    }
    void ValueChanged(int index)
    {
        GameManager.instance.SetDifficulty(dropdown.value);
    }
}
