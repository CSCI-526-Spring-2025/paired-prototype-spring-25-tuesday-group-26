using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountDown : MonoBehaviour
{
    public float totalTime = 30f;  
    private float remainingTime;

    public TextMeshProUGUI countdownText; 
    public GameObject outOfTimePanel; 

    private bool isTimeUp = false;

    void Start()
    {
        remainingTime = totalTime;
        UpdateTimerUI();
        outOfTimePanel.SetActive(false); 
    }

    void Update()
    {
        if (!isTimeUp)
        {
            remainingTime -= Time.deltaTime;  
            UpdateTimerUI();

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                isTimeUp = true;
                TimeOut();
            }
        }
    }

    void UpdateTimerUI()
    {
        countdownText.text = "Time Left: " + Mathf.Ceil(remainingTime) + "s";
    }

    void TimeOut()
    {
        outOfTimePanel.SetActive(true);  
        Time.timeScale = 0f;  
    }

    public void ClosePanel()
    {
        outOfTimePanel.SetActive(false);
        Time.timeScale = 1f; 
    }
}

