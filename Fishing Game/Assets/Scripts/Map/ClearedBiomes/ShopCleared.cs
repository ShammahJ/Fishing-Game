using UnityEngine;

public class ShopCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedClear1 == true)
        {
            MapGameManager.hasFinishedShop1 = true;
        }
        if (MapGameManager.hasFinishedRain1 == true)
        {
            MapGameManager.hasFinishedShop2 = true;
        }
        if (MapGameManager.hasFinishedSwamp1 == true || MapGameManager.hasFinishedClear2 == true)
        {
            MapGameManager.hasFinishedShop3 = true;
        }

    }
}
