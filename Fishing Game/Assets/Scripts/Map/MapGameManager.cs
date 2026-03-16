using System;
using Unity.Mathematics;
using UnityEngine;

public class MapGameManager : MonoBehaviour
{
    static public Vector3 shipPosition = new Vector3(135f, 560f, 0f);

    static public bool hasFinishedStart = false;
    static public bool hasFinishedClear1 = false;
    static public bool hasFinishedClear2 = false;
    static public bool hasFinishedClear3 = false;
    static public bool hasFinishedRain1 = false;
    static public bool hasFinishedRain2 = false;
    static public bool hasFinishedRain3 = false;
    static public bool hasFinishedSwamp1 = false;
    static public bool hasFinishedSwamp2 = false;
    static public bool hasFinishedShop1 = false;
    static public bool hasFinishedShop2 = false;
}
