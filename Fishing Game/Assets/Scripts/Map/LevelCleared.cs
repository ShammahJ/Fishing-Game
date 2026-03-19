using UnityEngine;

public class LevelCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.onStart == true)
        {
            MapGameManager.hasFinishedStart = true;
        }
        else if (MapGameManager.onClear1 == true)
        {
            MapGameManager.hasFinishedClear1 = true;
        }
        else if (MapGameManager.onClear2 == true)
        {
            MapGameManager.hasFinishedClear2 = true;
        }
        else if (MapGameManager.onClear3 == true)
        {
            MapGameManager.hasFinishedClear3 = true;
        }
        else if (MapGameManager.onRain1 == true)
        {
            MapGameManager.hasFinishedRain1 = true;
        }
        else if (MapGameManager.onRain2 == true)
        {
            MapGameManager.hasFinishedRain2 = true;
        }
        else if (MapGameManager.onSwamp1 == true)
        {
            MapGameManager.hasFinishedSwamp1 = true;
        }
        else if (MapGameManager.onSwamp2 == true)
        {
            MapGameManager.hasFinishedSwamp2 = true;
        }
        else if (MapGameManager.onShop1 == true)
        {
            MapGameManager.hasFinishedShop1 = true;
        }
        else if (MapGameManager.onShop2 == true)
        {
            MapGameManager.hasFinishedShop2 = true;
        }
        else if (MapGameManager.onShop3 == true)
        {
            MapGameManager.hasFinishedShop3 = true;
        }
    }

}
