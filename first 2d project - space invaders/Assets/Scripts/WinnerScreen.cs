using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour
{
    public TextMeshProUGUI FinalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FinalScore.text = "Final score: " + StaticTest.score * StaticTest.HP;
    }

    public void PlayAgainBtn()
    {
        SceneManager.LoadScene(0);
        StaticTest.score = 0;
        StaticTest.HP = 3;
    }
}
