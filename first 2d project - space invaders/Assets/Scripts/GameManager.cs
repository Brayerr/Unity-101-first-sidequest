using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public EnemyManager enemyManager;
    public Player player;
    public CanvasScript can;
    public int currentScene;
    public int updatedScore;


    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.playerDead == true)
        {            
            SceneManager.LoadScene(4); 
        }

        if (enemyManager.noMoreEnemies == true)
        {            
            NextScene(currentScene);
            Debug.Log("Congrats, you have killed all the enemies!");
            Debug.Log($"Level {currentScene +2}");            
        }
    }    

        void NextScene(int currentScene)
        {    
            SceneManager.LoadScene(currentScene + 1);
            currentScene += 1;            
        }
}

