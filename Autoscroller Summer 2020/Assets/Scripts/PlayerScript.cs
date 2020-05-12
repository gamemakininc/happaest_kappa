using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //idk
    Vector2 movement;
    //set health
    public int health = 100;
    //set death sprite
    public GameObject deathEffect;
    //build bullet 
    public Transform mgport;
    public GameObject BulletPrefab;
    //set speed
    public float MoveSpeed = 9f;
    //set player model
    public Rigidbody2D rb;
    public Animator animator;

    //Update called once per frame
    private void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        //animator variables
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    //delta time based  
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    void shoot()
    {
        //spawn bullet
        Instantiate(BulletPrefab, mgport.position, mgport.rotation);
    }
    public void TakeDamage(int damage)
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
        //spawn death sprite
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //remove self
        Destroy(gameObject);
    }
}