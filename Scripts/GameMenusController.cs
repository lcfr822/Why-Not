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

    // Start is called before the first frame update
    void Start()
    {
        endgameGroup.alpha = 0.0f;
        endgameGroup.blocksRaycasts = false;
        endgameGroup.interactable = false;

        TogglePauseMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !gameOver)
        {
            if (pauseGroup.alpha == 0) { TogglePauseMenu(true); }
            else { TogglePauseMenu(false); }
        }
    }

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

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
