using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: "+ StaticTest.score;
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
        StaticTest.score = 0;
        StaticTest.HP = 3;
    }
}
