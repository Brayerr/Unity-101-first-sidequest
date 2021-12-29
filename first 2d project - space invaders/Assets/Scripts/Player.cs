using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Rigidbody2D projectile, SlowProjectile;
    public int projSpeed = 20;
    public int slowProjSpeed = 10;
    public bool isDefaultProjectile = true;
    public bool playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") *speed *Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(moveX, moveY);
        
        if (transform.position.x >= screenBounds.x - objectWidth)
        {
            transform.position = new Vector3(screenBounds.x - objectWidth, transform.position.y, 0);
        }
        else if (transform.position.x <= -screenBounds.x + objectWidth)
        {
            transform.position = new Vector3(-screenBounds.x + objectWidth, transform.position.y, 0);
        }

        if(transform.position.y >= screenBounds.y - objectHeight)
        {
            transform.position = new Vector3(transform.position.x , screenBounds.y - objectHeight, 0);
        }
        else if(transform.position.y <= -screenBounds.y + objectHeight)
        {
            transform.position = new Vector3(transform.position.x, -screenBounds.y + objectHeight, 0);
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDefaultProjectile = !isDefaultProjectile;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isDefaultProjectile == true)
            Projectile1();
        else
            Projectile2();
    }

    public void PlayerDamage(int damage)
    {
        StaticTest.HP -= damage;
        if (StaticTest.HP <= 0)
        {
            Destroy(gameObject);
            playerDead = true;
        }            
    }

    public void Projectile1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D proj = Instantiate(projectile);
            proj.transform.position = transform.position;
            proj.velocity = Vector2.up * projSpeed;
        }
    }

    public void Projectile2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D proj = Instantiate(SlowProjectile);
            proj.transform.position = transform.position;
            proj.velocity = Vector2.up * slowProjSpeed;
        }
    }
}
