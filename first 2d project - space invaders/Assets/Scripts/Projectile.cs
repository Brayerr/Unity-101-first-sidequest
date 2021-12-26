using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.CompareTag("Enemy"))
        {
            Enemy enemys = coll.GetComponent<Enemy>();
            enemys.Damage(damage);
            Destroy(gameObject);
        }
    }
}
