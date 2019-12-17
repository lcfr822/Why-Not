using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup mainMenuGroup;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Toggles a specified CanvasGroup object that is shown while the main menu CanvasGroup is hidden.
    /// </summary>
    /// <param name="canvasGroup">Toggled CanvasGroup.</param>
    public void ToggleMainMenuGroup(CanvasGroup canvasGroup)
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;

            mainMenuGroup.alpha = 0;
            mainMenuGroup.blocksRaycasts = false;
            mainMenuGroup.interactable = false;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;

            mainMenuGroup.alpha = 1;
            mainMenuGroup.blocksRaycasts = true;
            mainMenuGroup.interactable = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
