using UnityEngine;

public class RainCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedStart == true)
        {
            MapGameManager.hasFinishedRain1 = true;
        }
        if (MapGameManager.hasFinishedSwamp1 == true)
        {
            MapGameManager.hasFinishedRain2 = true;
        }
        if (MapGameManager.hasFinishedClear3 == true || MapGameManager.hasFinishedSwamp2 == true)
        {
            MapGameManager.hasFinishedRain3 = true;
        }
    }
}
