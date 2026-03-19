using System;
using Unity.Mathematics;
using UnityEngine;

public class MapGameManager : MonoBehaviour
{
    static public Vector3 shipPosition = new Vector3(135f, 560f, 0f);
    
    // Testing states
    //static public bool hasFinishedStart = false;
    //static public bool hasFinishedClear1 = true;
    //static public bool hasFinishedClear2 = true;
    //static public bool hasFinishedClear3 = true;
    //static public bool hasFinishedRain1 = true;
    //static public bool hasFinishedRain2 = false;
    //static public bool hasFinishedSwamp1 = true;
    //static public bool hasFinishedSwamp2 = true;
    //static public bool hasFinishedShop1 = true;
    //static public bool hasFinishedShop2 = true;
    //static public bool hasFinishedShop3 = true;

    static public bool hasFinishedStart = false;
    static public bool hasFinishedClear1 = false;
    static public bool hasFinishedClear2 = false;
    static public bool hasFinishedClear3 = false;
    static public bool hasFinishedRain1 = false;
    static public bool hasFinishedRain2 = false;
    static public bool hasFinishedSwamp1 = false;
    static public bool hasFinishedSwamp2 = false;
    static public bool hasFinishedShop1 = false;
    static public bool hasFinishedShop2 = false;
    static public bool hasFinishedShop3 = false;

    static public bool onStart = true;
    static public bool onClear1 = false;
    static public bool onClear2 = false;
    static public bool onClear3 = false;
    static public bool onRain1 = false;
    static public bool onRain2 = false;
    static public bool onSwamp1 = false;
    static public bool onSwamp2 = false;
    static public bool onShop1 = false;
    static public bool onShop2 = false;
    static public bool onShop3 = false;

    static public void Reset()
    {
        shipPosition = new Vector3(135f, 560f, 0f);

        hasFinishedStart = false;
        hasFinishedClear1 = false;
        hasFinishedClear2 = false;
        hasFinishedClear3 = false;
        hasFinishedRain1 = false;
        hasFinishedRain2 = false;
        hasFinishedSwamp1 = false;
        hasFinishedSwamp2 = false;
        hasFinishedShop1 = false;
        hasFinishedShop2 = false;
        hasFinishedShop3 = false;

        onStart = true;
        onClear1 = false;
        onClear2 = false;
        onClear3 = false;
        onRain1 = false;
        onRain2 = false;
        onSwamp1 = false;
        onSwamp2 = false;
        onShop1 = false;
        onShop2 = false;
        onShop3 = false;
    }
}
