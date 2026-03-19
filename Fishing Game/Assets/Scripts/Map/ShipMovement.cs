using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameObject targetObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            MapGameManager.onStart = true;
        }
        else if (collision.gameObject.CompareTag("Clear1"))
        {
            MapGameManager.onClear1 = true;
        }
        else if (collision.gameObject.CompareTag("Clear2"))
        {
            MapGameManager.onClear2 = true;
        }
        else if (collision.gameObject.CompareTag("Clear3"))
        {
            MapGameManager.onClear3 = true;
        }
        else if (collision.gameObject.CompareTag("Rain1"))
        {
            MapGameManager.onRain1 = true;
        }
        else if (collision.gameObject.CompareTag("Rain2"))
        {
            MapGameManager.onRain2 = true;
        }
        else if (collision.gameObject.CompareTag("Swamp1"))
        {
            MapGameManager.onSwamp1 = true;
        }
        else if (collision.gameObject.CompareTag("Swamp2"))
        {
            MapGameManager.onSwamp2 = true;
        }
        else if (collision.gameObject.CompareTag("Shop1"))
        {
            MapGameManager.onShop1 = true;
        }
        else if (collision.gameObject.CompareTag("Shop2"))
        {
            MapGameManager.onShop2 = true;
        }
        else if (collision.gameObject.CompareTag("Shop3"))
        {
            MapGameManager.onShop3 = true;
        }
    }

    private void Update()
    {
        targetObject.transform.position = MapGameManager.shipPosition;

        if (MapGameManager.onStart == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedStart)
            {
                MapGameManager.onStart = false;
                targetObject.transform.position = new Vector2(380f, 760f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && MapGameManager.hasFinishedStart)
            {
                MapGameManager.onStart = false;
                targetObject.transform.position = new Vector2(510f, 315f);
            }
        }
        else if (MapGameManager.onClear1 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedClear1)
            {
                
                targetObject.transform.position = new Vector2(645f, 605f);
                MapGameManager.onClear1 = false;

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedClear1)
            {
                
                targetObject.transform.position = new Vector2(135f, 560f);
                MapGameManager.onClear1 = false;

            }
        }
        else if (MapGameManager.onClear2 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedClear2)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                MapGameManager.onClear2 = false;
            }
        }
        else if (MapGameManager.onClear3 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedClear3)
            {
                targetObject.transform.position = new Vector2(1697f, 572f);
                MapGameManager.onClear3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedClear3)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                MapGameManager.onClear3 = false;
            }

        }
        else if (MapGameManager.onRain1 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedRain1)
            {
                targetObject.transform.position = new Vector2(770f, 345f);
                MapGameManager.onRain1 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedRain1)
            {
                targetObject.transform.position = new Vector2(135f, 560f);
                MapGameManager.onRain1 = false;
            }
        }
        else if (MapGameManager.onRain2 == true)
        {
            // No movement options
        }
        else if (MapGameManager.onSwamp1 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedSwamp1)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                MapGameManager.onSwamp1 = false;
            }
        }
        else if (MapGameManager.onSwamp2 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedSwamp2)
            {
                targetObject.transform.position = new Vector2(1697f, 572f);
                MapGameManager.onSwamp2 = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !MapGameManager.hasFinishedSwamp2)
            {
                targetObject.transform.position = new Vector2(1130f, 585f);
                MapGameManager.onSwamp2 = false;
            }
        }
        else if (MapGameManager.onShop1 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedShop1)
            {
                targetObject.transform.position = new Vector2(875f, 785f);
                MapGameManager.onShop1 = false;
            }
        }
        else if (MapGameManager.onShop2 == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && MapGameManager.hasFinishedShop2)
            {
                targetObject.transform.position = new Vector2(1060f, 340f);
                MapGameManager.onShop2 = false;
            }
        }
        else if (MapGameManager.onShop3 == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && MapGameManager.hasFinishedShop3)
            {
                targetObject.transform.position = new Vector2(1340f, 740f);
                MapGameManager.onShop3 = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && MapGameManager.hasFinishedShop3)
            {
                targetObject.transform.position = new Vector2(1430f, 440f);
                MapGameManager.onShop3 = false;
            }
        }

        if (targetObject.transform.position != MapGameManager.shipPosition)
        {
            MapGameManager.shipPosition = targetObject.transform.position;
        }
    }
}
