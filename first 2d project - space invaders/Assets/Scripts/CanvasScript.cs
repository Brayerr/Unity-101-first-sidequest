using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreCounter, HealthCounter;
    public Player player;
    public EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCounter.text = "Score: " + StaticTest.score;
        HealthCounter.text = "Health: " + StaticTest.HP;                
    }


}
