using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// A hud script to control the UI of the game
/// </summary>
public class HUD : MonoBehaviour
{
    //the player ref
    public Player player;

    //the UI objects you have to have to see
    [Header("Requirements")]
    public TextMeshProUGUI hitsLabel;
    public TextMeshProUGUI timerLabel;
    public Image forceBar;

    private void Update()
    {
        //updating player game hits
        if(hitsLabel)
            hitsLabel.text = player.hits.ToString();
        //updating player turn duration
        if(timerLabel)
            timerLabel.text = ((int)player.turnDurationLeft).ToString();
        //updating player shoot force
        if (forceBar)
            forceBar.fillAmount = player.currForce / player.maxForce;
    }

    public void OnCompleted()
    {
        timerLabel.gameObject.SetActive(false);
        forceBar.gameObject.SetActive(false);
        enabled = false;

        //show win title
    }
}
