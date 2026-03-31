using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdjustSceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private float chargeSpeed = 50f; // money per second
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chargeTickSFX;
    [SerializeField] private float tickInterval = 0.05f; // max SFX rate
    private float tickTimer = 0f;
    private int lastWholeMoney;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.instance;

        // Show day
        dayText.text = "Day " + (gm.level + 1);

        

        // Start charging animation
        StartCoroutine(ChargeQuota());


    }

    IEnumerator ChargeQuota()
    {
        float remainingDebt = gm.debt;
        lastWholeMoney = Mathf.FloorToInt(gm.money);

        tickTimer = 0f;

        while (remainingDebt > 0 && gm.money > 0)
        {
            float charge = chargeSpeed * Time.deltaTime;

            // clamp so we don’t overcharge
            charge = Mathf.Min(charge, remainingDebt);

            gm.LoseMoney(charge);
            remainingDebt -= charge;

            // Play sound ONLY when a whole dollar is lost
            // Playing every decimal will freeze the game. (Learned the hard way)
            int currentWholeMoney = Mathf.FloorToInt(gm.money);
            tickTimer -= Time.deltaTime;

            if (currentWholeMoney < lastWholeMoney)
            {
                audioSource.PlayOneShot(chargeTickSFX);
                lastWholeMoney = currentWholeMoney;
                audioSource.PlayOneShot(chargeTickSFX);
                lastWholeMoney = currentWholeMoney;
                tickTimer = tickInterval; // prevent audio spam
            }

            //audioSource.PlayOneShot(chargeTickSFX);
            yield return null;
        }

        yield return new WaitForSeconds(3f);

        // After charging --> check result
        if (remainingDebt > 0)
        {
            SceneManager.LoadScene("LossScreen");
        }
        else
        {
            //gm.LoseMoney(gm.debt);
            SceneManager.LoadScene("Map");
        }
    }
}