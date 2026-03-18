using UnityEngine;

public class SwampCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedShop1 == true)
        {
            MapGameManager.hasFinishedSwamp1 = true;
        }
        if (MapGameManager.hasFinishedShop3 == true)
        {
            MapGameManager.hasFinishedSwamp2 = true;
        }
    }
}
