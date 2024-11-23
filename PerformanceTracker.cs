using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTracker : MonoBehaviour
{
    public event Action<string> OnDifficultyChange; 

    private float startTime;
    private int retryCount;
    private int correctAnswers;
    private int totalQuestions;

    public XPSystem xpSystem;

    public void StartTracking(int totalQuestions)
    {
        this.totalQuestions = totalQuestions;
        correctAnswers = 0;
        retryCount = 0;
        startTime = Time.time;
    }

    public void RegisterRetry()
    {
        retryCount++;
    }

    public void RegisterCorrectAnswer()
    {
        correctAnswers++;
        CheckPerformance();
    }

    private void CheckPerformance()
    {
        float elapsedTime = Time.time - startTime;

        
        if (retryCount > 3 || elapsedTime > 60) // Struggling
        {
            OnDifficultyChange?.Invoke("Easy");
            GiveReward(true);
        }
        else if (correctAnswers / (float)totalQuestions > 0.8f) // Excelling
        {
            OnDifficultyChange?.Invoke("Hard");
        }
        else // Average
        {
            OnDifficultyChange?.Invoke("Medium");
            GiveReward(false);   
        }
    }

    public void GiveReward(bool completed)
    {
        if (completed)
        {
            xpSystem.AddXP(50); 
            Debug.Log("Reward: Bonus XP awarded!");
        }
        else
        {
            Debug.Log("Keep trying! You're doing great!");
        }
    }
}
