using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerScript : MonoBehaviour
{
    //idk
    Vector2 movement;
    //set health (for gameplay)
    public int health;
    //set death sprite
    public GameObject deathEffect;
    //build bullet 
    public int payload0Selector;
    public int payload1Selector;
    public Transform[] wPorts;
    public Transform mgport;
    public GameObject[] BulletPrefabs;
    public GameObject[] MissilePrefabs;
    public int bulletSelector;
    //set speed
    public float MoveSpeed;
    public float forwardSpeed = 0.7f;
    //set player model
    public Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        //set variables from observer
        health = ObserverScript.Instance.phealth;
        bulletSelector = ObserverScript.Instance.pBulletSelector;
        //??
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (health == 0)
        {
            health = 100;
        }
        if (MoveSpeed == 0f) 
        {
            MoveSpeed = 9f;
        }
        //set launcher ammo baced on selectors
    }

    //Update called once per frame
    private void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        //animator variables
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    //delta time based  
    private void FixedUpdate()
    {
        //if statement limmits speed in forward direction
        if(movement.y > 0)
        {
            rb.MovePosition(rb.position + movement * MoveSpeed  * forwardSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }
        
    }
    void p0shoot() 
    {
        //spawn item saved in payload0 (remove 1 ammo later problem) 
        //slot 0 skip or set to spawn unlimited dummys
    }
    void p1shoot()
    {
        //spawn item saved in payload1 (remove 1 ammo later problem)
        //slot 0 skip or set to spawn unlimited dummys
    }
    public void Shoot()
    {
        //spawn bullet
        Instantiate(BulletPrefabs[bulletSelector], mgport.position, mgport.rotation);
    }
    public void TakeDamage(int damage)
    {
        //take damage
        health -= damage;
        //check health
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //spawn death sprite (wip)
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //remove self
        Destroy(gameObject);
    }
}