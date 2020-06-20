﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    //set death sprite
    public GameObject deathEffect;
    //set health
    public float health = 10;
    //loot table var
    public powerupHandeler thisPowerup;

    void Start()
    {
        thisPowerup = GetComponent<powerupHandeler>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if player/get player script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            //damage player
            player.TakeDamage(health);
            //remove enemy
            Destroy(gameObject);
        }
    }

    //handel for bullet script
    public void TakeDamage(float damage)
    {
        health -= damage;
        //check health
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //allow skip if no death animation set
        if (deathEffect != null)
        {
            //spawn death animation prefab
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        makeLoot();
        //remove self
        Destroy(gameObject);
    }

    void makeLoot()
    {
        if (thisPowerup != null)
        {
            thisPowerup.dropCalcultation();
        }
        //remove self
        Destroy(gameObject);
    }
}
