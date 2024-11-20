using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "XPConfig", menuName = "Configs/XPConfig")]
public class XPConfigSO : ScriptableObject
{
    [SerializeField] private int[] xpThresholds;

    public int GetXPForNextLevel(int currentLevel)
    {
        if (currentLevel < xpThresholds.Length)
            return xpThresholds[currentLevel];
        return xpThresholds[xpThresholds.Length - 1];
    }
}
