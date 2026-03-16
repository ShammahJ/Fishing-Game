using UnityEngine;

public class SwampCleared : MonoBehaviour
{
    void Start()
    {
        if (MapGameManager.hasFinishedClear1 == true)
        {
            MapGameManager.hasFinishedSwamp1 = true;
        }
        if (MapGameManager.hasFinishedShop2 == true)
        {
            MapGameManager.hasFinishedSwamp2 = true;
        }
    }
}
