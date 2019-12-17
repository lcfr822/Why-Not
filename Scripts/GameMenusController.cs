using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenusController : MonoBehaviour
{
    public CanvasGroup endgameGroup, pauseGroup;
    public Text[] endgameScoreTexts = new Text[3];

    private bool gameOver = false;

    void Start()
    {
        endgameGroup.alpha = 0.0f;
        endgameGroup.blocksRaycasts = false;
        endgameGroup.interactable = false;

        TogglePauseMenu(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            if (pauseGroup.alpha == 0) { TogglePauseMenu(true); }
            else { TogglePauseMenu(false); }
        }
    }

    /// <summary>
    /// Enables of disables the pause state and shows or hides pause menu accordingly.
    /// </summary>
    /// <param name="enabled">Value determining pause status.</param>
    public void TogglePauseMenu(bool enabled)
    {
        if (enabled)
        {
            FindObjectOfType<MasterGameplayManager>().gameRunning = false;
            pauseGroup.alpha = 1;
            pauseGroup.blocksRaycasts = true;
            pauseGroup.interactable = true;
        }
        else
        {
            FindObjectOfType<MasterGameplayManager>().gameRunning = true;
            pauseGroup.alpha = 0;
            pauseGroup.blocksRaycasts = false;
            pauseGroup.interactable = false;
        }
    }

    /// <summary>
    /// Terminate the gameplay session and show the final scores.
    /// </summary>
    public void ShowEndgameMenu()
    {
        gameOver = true;
        MasterGameplayManager gameplayManager = FindObjectOfType<MasterGameplayManager>();
        endgameScoreTexts[0].text = "Base Score: " + gameplayManager.baseScore.ToString("#,###.##");
        endgameScoreTexts[1].text = "Accuracy Score: " + gameplayManager.accuracyScore.ToString("#,###.##");
        endgameScoreTexts[2].text = "Total Score: " + gameplayManager.totalScore.ToString("#,###.##");
        gameplayManager.gameRunning = false;
        endgameGroup.alpha = 1.0f;
        endgameGroup.blocksRaycasts = true;
        endgameGroup.interactable = true;
    }

    /// <summary>
    /// Restart play.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Return to the main menu.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Exit the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
