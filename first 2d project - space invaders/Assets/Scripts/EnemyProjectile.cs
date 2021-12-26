using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 1;
    public Player player;

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("Player"))
        {
            Player player = coll.GetComponent<Player>();
            player.PlayerDamage(damage);
            Destroy(gameObject);
        }
    }

    

}
