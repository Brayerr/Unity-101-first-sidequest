using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 10;
    public int projSpeed = 10;
    public Animator anim;
    public Rigidbody2D EnemyProjectile;
    public float shtChance = .3f;
    public int damage = 1;
    public float fireRate = 3;
    public EnemyManager manager;
    public Player player;
    public int scoreValue;
    [SerializeField]
    private int currentHP;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HP;
        InvokeRepeating("ShootChance", 1, fireRate);                      
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rand = new System.Random();
        scoreValue = rand.Next(10, 100);
    }

    public void Damage(int damage)
    {
        if (currentHP <= 0)
            return;
        
        currentHP -= damage;
        if (currentHP <= 0)
        {
            anim.SetTrigger("Exploading");            
            Destroy(gameObject, 1f);           
            manager.EnemyDestroyed(this);            
            StaticTest.score += scoreValue;
        }
    }

 
    public bool ShootChance()
    {
        System.Random rand = new System.Random();

        if(rand.NextDouble() <= shtChance)
        {
            Rigidbody2D proj = Instantiate(EnemyProjectile);
            proj.transform.position = transform.position;
            proj.velocity = Vector2.down * projSpeed;
            return true;
        }
        else
        {
            return false;
        }

        
    }

    

    
}
