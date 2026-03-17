using UnityEngine;

public class PopupToggle : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        panel.SetActive(true); // make sure it's hidden at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            panel.SetActive(!panel.activeSelf); // toggle on/off
        }
    }
}
