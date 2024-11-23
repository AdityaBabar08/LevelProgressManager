using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAdjuster : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard }
    private Difficulty currentDifficulty;

    public void SetDifficulty(string difficultyLevel)
    {
        currentDifficulty = difficultyLevel switch
        {
            "Easy" => Difficulty.Easy,
            "Medium" => Difficulty.Medium,
            "Hard" => Difficulty.Hard,
            _ => currentDifficulty
        };

        Debug.Log("Difficulty adjusted to: " + currentDifficulty);
    }
}
