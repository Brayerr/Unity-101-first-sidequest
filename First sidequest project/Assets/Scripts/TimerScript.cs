using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public float currentTime = 0f;
    public int minuteCounter = 0;
    public int tenMinutes = 0;
 
    // Start is called before the first frame update
    void Start()
    {       
   
    }

    // Update is called once per frame
     void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60)
        {
            minuteCounter++;
            currentTime = 0f;
            if(minuteCounter >= 10)
            {
                tenMinutes++;
                minuteCounter = 0;
            }
        }
    }
}
