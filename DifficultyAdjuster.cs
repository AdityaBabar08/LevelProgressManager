using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAdjuster : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    private Difficulty currentDifficulty;

    public Difficulty GetCurrentDifficulty()
    {
        return currentDifficulty;
    }

    public void AdjustDifficulty(int playerLevel)
    {
        if (playerLevel < 5)
            currentDifficulty = Difficulty.Easy;
        else if (playerLevel < 10)
            currentDifficulty = Difficulty.Medium;
        else
            currentDifficulty = Difficulty.Hard;

        Debug.Log("Difficulty adjusted to: " + currentDifficulty);
    }
}
