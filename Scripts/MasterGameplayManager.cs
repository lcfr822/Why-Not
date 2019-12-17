using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterGameplayManager : MonoBehaviour
{
    public bool gameRunning = true;
    public Text scoreText;

    public float baseScore { get; private set; } = 0.0f;
    public float accuracyScore { get; private set; } = 0.0f;
    public float totalScore { get; private set; } = 0.0f;

    /// <summary>
    /// Increase the player's score values by specified amounts and update the Score UI element.
    /// </summary>
    /// <param name="baseAmount">Always equal to 10.</param>
    /// <param name="accuracyAmount">Value between -5 and 5 to be added to the base score.</param>
    public void AddScore(float baseAmount, float accuracyAmount)
    {
        baseScore += baseAmount;
        accuracyScore += accuracyAmount;
        totalScore = baseScore + accuracyScore;
        scoreText.text = "Score: " + totalScore.ToString("#,###.##");
    }
}
