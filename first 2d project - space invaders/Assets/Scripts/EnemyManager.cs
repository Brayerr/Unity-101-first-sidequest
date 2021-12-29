using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 1;
    private int direction;
    Vector2 screenBounds;
    public float extraSpace = 4.5f;
    public int enemiesCount;
    public bool noMoreEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        noMoreEnemies = false;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
       
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].manager = this;
        }
      
        enemiesCount = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime * direction;

        if (direction > 0 && transform.position.x > screenBounds.x - extraSpace)       
            direction *= -1;
        
        else if (direction < 0 && transform.position.x < -screenBounds.x + extraSpace)
            direction *= -1;
        
    }

    public void EnemyDestroyed(Enemy enemy)
    {
        enemiesCount--;
        if (enemiesCount == 0)
        {
            noMoreEnemies = true;           
        }
    }
}
