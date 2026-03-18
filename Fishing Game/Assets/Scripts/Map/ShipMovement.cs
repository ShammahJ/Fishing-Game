using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem.WebGL;

public class ShipMovement : MonoBehaviour
{
    public GameObject targetObject;

    private bool onStart;
    private bool onClear1;
    private bool onClear2;
    private bool onClear3;
    private bool onRain1;
    private bool onRain2;
    private bool onSwamp1;
    private bool onSwamp2;
    private bool onShop1;
    private bool onShop2;
    private bool onShop3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            onStart = true;
        }
        else if (collision.gameObject.CompareTag("Clear1"))
        {
            onClear1 = true;
        }
        else if (collision.gameObject.CompareTag("Clear2"))
        {
            onClear2 = true;
        }
        else if (collision.gameObject.CompareTag("Clear3"))
        {
            onClear3 = true;
        }
        else if (collision.gameObject.CompareTag("Rain1"))
        {
            onRain1 = true;
        }
        else if (collision.gameObject.CompareTag("Rain2"))
        {
            onRain2 = true;
        }
        else if (collision.gameObject.CompareTag("Swamp1"))
        {
            onSwamp1 = true;
        }
        else if (collision.gameObject.CompareTag("Swamp2"))
        {
            onSwamp2 = true;
        }
        else if (collision.gameObject.CompareTag("Shop1"))
        {
            onShop1 = true;
        }
        else if (collision.gameObject.CompareTag("Shop2"))
        {
            onShop2 = true;
        }
        else if (collision.gameObject.CompareTag("Shop3"))
        {
            onShop3 = true;
        }
    }

    private void Update()
    {
        targetObject.transform.position = MapGameManager.shipPosition;

        if (onStart == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedStart)
            {
                onStart = false;
                targetObject.transform.position = new Vector2(380f, 760f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && MapGameManager.hasFinishedStart)
            {
                onStart = false;
                targetObject.transform.position = new Vector2(510f, 315f);
            }
        }
        else if (onClear1 == true)
        {
            onStart = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedClear1)
            {
                
                targetObject.transform.position = new Vector2(645f, 605f);
                onClear1 = false;

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedClear1)
            {
                
                targetObject.transform.position = new Vector2(135f, 560f);
                onClear1 = false;

            }
        }
        else if (onClear2 == true)
        {
            onStart = false;
            onShop2 = false;

            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedClear2)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                onClear2 = false;
            }
        }
        else if (onClear3 == true)
        {
            onStart = false;
            onShop3 = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedClear3)
            {
                targetObject.transform.position = new Vector2(1697f, 572f);
                onClear3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedClear3)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                onClear3 = false;
            }

        }
        else if (onRain1 == true)
        {
            onStart = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedRain1)
            {
                targetObject.transform.position = new Vector2(770f, 345f);
                onRain1 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedRain1)
            {
                targetObject.transform.position = new Vector2(135f, 560f);
                onRain1 = false;
            }
        }
        else if (onRain2 == true)
        {
            onStart = false;
            onClear3 = false;
            onSwamp2 = false;

            // No movement options
        }
        else if (onSwamp1 == true)
        {
            onStart = false;
            onShop1 = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedSwamp1)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                onSwamp1 = false;
            }
        }
        else if (onSwamp2 == true)
        {
            onStart = false;
            onShop3 = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedSwamp2)
            {
                targetObject.transform.position = new Vector2(1697f, 572f);
                onSwamp2 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedSwamp2)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                onSwamp2 = false;
            }
        }
        else if (onShop1 == true)
        {
            onStart = false;
            onClear1 = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedShop1)
            {
                targetObject.transform.position = new Vector2(875f, 785f);
                onShop1 = false;
            }
        }
        else if (onShop2 == true)
        {
            onStart = false;
            onRain1 = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedShop2)
            {
                targetObject.transform.position = new Vector2(1060f, 340f);
                onShop2 = false;
            }
        }
        else if (onShop3 == true)
        {
            onStart = false;
            onSwamp1 = false;
            onClear2 = false;

            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedShop3)
            {
                targetObject.transform.position = new Vector2(1340f, 740f);
                onShop3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && MapGameManager.hasFinishedShop3)
            {
                targetObject.transform.position = new Vector2(1430f, 440f);
                onShop3 = false;
            }
        }

        if (targetObject.transform.position != MapGameManager.shipPosition)
        {
            MapGameManager.shipPosition = targetObject.transform.position;
        }
    }
}
