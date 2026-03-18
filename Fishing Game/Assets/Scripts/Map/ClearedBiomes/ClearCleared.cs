using UnityEngine;

public class ClearCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedStart == true)
        {
            MapGameManager.hasFinishedClear1 = true;
        }
        if (MapGameManager.hasFinishedShop2 == true)
        {
            MapGameManager.hasFinishedClear2 = true;
        }
        if (MapGameManager.hasFinishedShop3 == true)
        {
            MapGameManager.hasFinishedClear3 = true;
        }
    }
}
