using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button clear1;
    public Button clear2;
    public Button clear3;
    public Button rain1;
    public Button rain2;
    public Button swamp1;
    public Button swamp2;
    public Button shop1;
    public Button shop2;
    public Button shop3;
    public Button start;

    void Start()
    {
        clear1.enabled = false;
        clear2.enabled = false;
        clear3.enabled = false;
        rain1.enabled = false;
        rain2.enabled = false;
        swamp1.enabled = false;
        swamp2.enabled = false;
        shop1.enabled = false;
        shop2.enabled = false;
        shop3.enabled = false;
        start.enabled = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Clear1"))
        {
            if (!MapGameManager.hasFinishedClear1)
            {
                clear1.enabled = true;
            }

            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Clear2"))
        {
            if (!MapGameManager.hasFinishedClear2)
            {
                clear2.enabled = true;
            }

            clear1.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Clear3"))
        {
            if (!MapGameManager.hasFinishedClear3)
            {
                clear3.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Rain1"))
        {
            if (!MapGameManager.hasFinishedRain1)
            {
                rain1.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Rain2"))
        {
            if (!MapGameManager.hasFinishedRain2)
            {
                rain2.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        //else if (collision.gameObject.CompareTag("Rain3"))
        //{
        //    if (!MapGameManager.hasFinishedRain3)
        //    {
        //        rain3.enabled = true;
        //    }

        //    clear1.enabled = false;
        //    clear2.enabled = false;
        //    clear3.enabled = false;
        //    rain1.enabled = false;
        //    rain2.enabled = false;
        //    swamp1.enabled = false;
        //    swamp2.enabled = false;
        //    shop1.enabled = false;
        //    shop2.enabled = false;
        //    start.enabled = false;
        //}
        else if (collision.gameObject.CompareTag("Swamp1"))
        {
            if (!MapGameManager.hasFinishedSwamp1)
            {
                swamp1.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Swamp2"))
        {
            if (!MapGameManager.hasFinishedSwamp2)
            {
                swamp2.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Shop1"))
        {
            if (!MapGameManager.hasFinishedShop1)
            {
                shop1.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Shop2"))
        {
            if (!MapGameManager.hasFinishedShop2)
            {
                shop2.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop3.enabled = false;
            start.enabled = false;
        }
        else if (collision.gameObject.CompareTag("Shop3"))
        {
            if (!MapGameManager.hasFinishedShop3)
            {
                shop3.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            start.enabled = false;
        }

        else if (collision.gameObject.CompareTag("Start"))
        {
            if (!MapGameManager.hasFinishedStart)
            {
                start.enabled = true;
            }

            clear1.enabled = false;
            clear2.enabled = false;
            clear3.enabled = false;
            rain1.enabled = false;
            rain2.enabled = false;
            swamp1.enabled = false;
            swamp2.enabled = false;
            shop1.enabled = false;
            shop2.enabled = false;
            shop3.enabled = false;
        }
    }
}
