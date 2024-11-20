using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class XPSystem : MonoBehaviour
{
    private int currentXP = 0;
    private int level = 0;

    [SerializeField] private XPConfigSO xpConfig;

    public void AddXP(int amount)
    {
        currentXP += amount;
        CheckLevelUp();
    }

    public bool CheckLevelUp()
    {
        if (currentXP >= xpConfig.GetXPForNextLevel(level))
        {
            LevelUp();
            currentXP = 0;
            Debug.Log("Level Up! New level: " + level);
            return true;
        }
        return false;
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelUp()
    {
        level++;
    }

    public int GetCurrentXP()
    {
        return currentXP;
    }

    public float GetNormalizedXP()
    {
        return (float)currentXP / xpConfig.GetXPForNextLevel(level);
    }
}
