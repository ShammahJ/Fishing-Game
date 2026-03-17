using UnityEngine;

public class ShopCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedRain1 == true)
        {
            MapGameManager.hasFinishedShop1 = true;
        }
        if (MapGameManager.hasFinishedRain2 == true || MapGameManager.hasFinishedClear2 == true)
        {
            MapGameManager.hasFinishedShop2 = true;
        }

    }
}
