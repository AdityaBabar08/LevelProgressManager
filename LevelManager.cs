using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem;
    [SerializeField] private DifficultyAdjuster difficultyAdjuster;
    public PerformanceTracker performanceTracker;
    private int currentSubLevel = 0;
    [SerializeField] private int totalSubLevelsPerLevel = 3;

    void Start()
    {
        performanceTracker.OnDifficultyChange += difficultyAdjuster.SetDifficulty;
        StartNewSubLevel();
    }



    void Update()
    {
        if (xpSystem.CheckLevelUp())
        {
            currentSubLevel = 0;
            xpSystem.LevelUp();
            StartNewSubLevel();
        }
        else if (CheckSubLevelCompletion())
        {
            currentSubLevel++;
            StartNewSubLevel();
        }
    }

    void StartNewSubLevel()
    {
        performanceTracker.StartTracking(GetTotalQuestionsForCurrentSubLevel());
    }

    int GetTotalQuestionsForCurrentSubLevel()
    {
        
        return 10 + xpSystem.GetLevel() * 2;
    }

    bool CheckSubLevelCompletion()
    {
        
        return xpSystem.GetCurrentXP() >= GetXPThresholdForNextSubLevel();
    }

    int GetXPThresholdForNextSubLevel()
    {
        return xpSystem.GetLevel() * 100 + currentSubLevel * 50;
    }

    
}
