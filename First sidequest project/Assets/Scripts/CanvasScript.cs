using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreCounter,Timer;    
    public Player player;
    public TimerScript timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCounter.text = "Score:" + player.score;
        Timer.text = "Time passed : "+timer.tenMinutes+timer.minuteCounter +":"+ timer.currentTime.ToString("f2");

    }



    
}
