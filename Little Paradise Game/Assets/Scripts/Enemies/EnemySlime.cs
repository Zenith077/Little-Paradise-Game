using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(navm))]
public class EnemySlime : Enemy, IDamageable
{
    public void TakeDamage(float dmg)
    {
        health = health - dmg;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //if (Input.GetKeyDown(KeyCode.E))
        Movement();
    }

    
}
