using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossZoneController : MonoBehaviour
{
    private int healthIndex = 5;

    public CanvasGroup endgameGroup;
    public Image[] healthImages = new Image[5];

    /// <summary>
    /// Detect trigger entry in the loss zone and decrease health if the decrease results in a number greater than zero.
    /// Otherwise decrease health to zero and end the game.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!FindObjectOfType<MasterGameplayManager>().gameRunning) { return; }

        if (collision.gameObject.tag.ToLower().Equals("ball") && !collision.gameObject.name.ToLower().Contains("dead"))
        {
            if(healthIndex - 1 > 0)
            {
                healthIndex--;
                healthImages[healthIndex].gameObject.SetActive(false);
            }
            else
            {
                healthIndex--;
                healthImages[healthIndex].gameObject.SetActive(false);
                FindObjectOfType<GameMenusController>().ShowEndgameMenu();
            }
        }
    }
}
