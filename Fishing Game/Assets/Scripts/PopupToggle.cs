using UnityEngine;

public class PopupToggle : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private string id;
    void Start()
    {
        if ( GameManager.instance.tutorialSeen.ContainsKey(id) && GameManager.instance.tutorialSeen[id]) {
            print("Hidden because we already saw");
            panel.SetActive(false);
            return;
        }
        panel.SetActive(true); // make sure it's hidden at start
        GameManager.instance.tutorialSeen.Add(id,true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            panel.SetActive(!panel.activeSelf); // toggle on/off
        }
    }
}
