using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    public Text countdownText;

    private void Start()
    {
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
    }
}
