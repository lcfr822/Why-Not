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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float baseAmount, float accuracyAmount)
    {
        baseScore += baseAmount;
        accuracyScore += accuracyAmount;
        totalScore = baseScore + accuracyScore;
        scoreText.text = "Score: " + totalScore.ToString("#,###.##");
    }
}
