using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonDefinition : MonoBehaviour
{
    public bool selected = false;
    private Button button;

    private bool disableControls = false;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void SwappedTo()
    {
        selected = true;
    }

    public void SwappedOff()
    {
        selected = false;
    }
    public void ClickButton()
    {
        if (!disableControls)
        {
            disableControls = true;

            button.onClick.Invoke();

            disableControls = false;
        }
    }

    public bool GetDisbaleControls()
    {
        return disableControls;
    }
}
