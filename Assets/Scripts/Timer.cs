using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 30f;
    [SerializeField] float correctAnswerTime = 10f;
    public bool loadNextQuestion = true;
    public bool isAnswering = true;
    public float fillFraction;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() 
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if(isAnswering) {
            if(timerValue > 0) {
                fillFraction = timerValue / timeToAnswer;
            } else {
                isAnswering = false;
                timerValue = correctAnswerTime;
            }
        } else {
            if(timerValue > 0) {
                fillFraction = timerValue / correctAnswerTime;
            } else {
                isAnswering = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }
        Debug.Log("Is Answering?: " + isAnswering + " Timer Value:" + timerValue + " Fill Fraction:" + fillFraction);
    }
}
