using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    public Text countdownText;
    public GameObject timeUpBanner;
    public GameObject replayButton;

    private void Start()
    {
        if (timeUpBanner != null)
        {
            timeUpBanner.SetActive(false);
        }
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;
        while (currentTime > 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);

            countdownText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds
            );

            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        countdownText.text = "00:00:00";

        Time.timeScale = 0f;

        if (timeUpBanner != null)
        {
            timeUpBanner.SetActive(true);
            Text bannerText = timeUpBanner.GetComponentInChildren<Text>();
            if (bannerText != null)
            {
                bannerText.text = "Time is up, you failed";
            }
            Time.timeScale = 0f;

            if (replayButton != null)
            {
                replayButton.SetActive(true);
            }
        }
    }
}
