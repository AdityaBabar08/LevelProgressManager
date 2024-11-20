using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private XPSystem xpSystem;
    [SerializeField] private DifficultyAdjuster difficultyAdjuster;

    private int currentSubLevel = 0;
    [SerializeField] private int totalSubLevelsPerLevel = 3;

    void Update()
    {
        difficultyAdjuster.AdjustDifficulty(xpSystem.GetLevel());

        if (xpSystem.CheckLevelUp())
        {
            currentSubLevel = 0;
            xpSystem.LevelUp();
        }
        else if (CheckSubLevelCompletion())
        {
            currentSubLevel++;
            difficultyAdjuster.AdjustDifficulty(xpSystem.GetLevel());
        }
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
