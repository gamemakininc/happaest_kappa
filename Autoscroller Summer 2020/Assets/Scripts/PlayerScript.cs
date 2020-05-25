using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerScript : MonoBehaviour
{
    //idK
    Vector2 movement;
    //set health (for gameplay)
    public int maxHealth;
    public float health;
    public float repair;
    //shield and regen
    public int maxShield;
    public float shield;
    public float sRegen = .5f;
    //set death sprite
    public GameObject deathEffect;
    //build bullet 
    public int payload0Selector;
    public int payload1Selector;
    public int payload0Ammo;
    public int payload1Ammo;
    public Transform[] wPorts;
    public GameObject[] BulletPrefabs;
    public GameObject[] MissilePrefabs;
    public int bulletSelector;
    public int mslBonus;
    //set speed
    public float MoveSpeed = 6;
    public float forwardSpeed = 0.7f;
    //set player model
    public Rigidbody2D rb;
    public Animator animator;
    //swap variables
    private bool portSwap;
    private bool hasFired = false;
    //timers
    private float refireTime;
    public float nextFire;
    //audio
    public AudioClip[] sounds;
    public AudioSource audioSource;
    private void Start()
    {
        //set variables from observer
        shield = ObserverScript.Instance.pShield;
        sRegen = ObserverScript.Instance.pSRegen;
        health = ObserverScript.Instance.pHealth;
        repair = ObserverScript.Instance.pRepair;
        MoveSpeed = ObserverScript.Instance.pSpeed;
        bulletSelector = ObserverScript.Instance.pBulletSelector -1;
        payload0Selector = ObserverScript.Instance.pP0-1;
        payload1Selector = ObserverScript.Instance.pP1-1;
        mslBonus = ObserverScript.Instance.mslBonus;
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
        if (payload0Selector == 0){ payload0Ammo = 20 + mslBonus; }
        else if (payload0Selector == 1) { payload0Ammo = 15 + mslBonus; }
        else if (payload0Selector == 2) { payload0Ammo = 10 + mslBonus; }
        if (payload1Selector == 0) { payload0Ammo = 20 + mslBonus; }
        else if (payload1Selector == 1) { payload1Ammo = 15 + mslBonus; }
        else if (payload1Selector == 2) { payload1Ammo = 10 + mslBonus; }
        //fire rate augments
        if (bulletSelector == 2) { nextFire += 0.25f; }
        else if (bulletSelector == 0) { nextFire -= 0.15f; }
        //check for payloadexpanders


        //load audio
        audioSource = GetComponent<AudioSource>();
    }

    //Update called once per frame
    private void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Fire1") && Time.time > refireTime)
        {
            Shoot();
            if (bulletSelector == 2) { audioSource.PlayOneShot(sounds[0]); }
            else if (bulletSelector ==0 ) { audioSource.PlayOneShot(sounds[1]); }
            else if (bulletSelector == 1) { audioSource.PlayOneShot(sounds[1]); }
            else if (bulletSelector == 3) { audioSource.PlayOneShot(sounds[4]); }
            else if (bulletSelector == 4) { audioSource.PlayOneShot(sounds[4]); }
            else if (bulletSelector == 5) { audioSource.PlayOneShot(sounds[4]); }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            p0shoot();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            p1shoot();
        }
        //animator variables
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (health < maxHealth)
        { 
            health += repair * Time.deltaTime;
        }
        if (shield < maxShield)
        {
            shield += sRegen * Time.deltaTime;
        }

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
        //spawn item saved in payload0 and remove ammo 
        if (portSwap == true)
        {
            if (payload0Ammo >= 1) 
            {
                    Instantiate(MissilePrefabs[payload0Selector], wPorts[0].position, wPorts[0].rotation);
                    portSwap = false;
                    payload0Ammo--;
                    hasFired = true;
                    audioSource.PlayOneShot(sounds[2]);
            }
        }
        if (portSwap == false)
        {
            if (payload0Ammo >= 1)
            {
                if (hasFired == false)
                {
                    Instantiate(MissilePrefabs[payload0Selector], wPorts[1].position, wPorts[1].rotation);
                    portSwap = true;
                    payload0Ammo--;
                    audioSource.PlayOneShot(sounds[2]);
                }
            }
        }
        hasFired = false;
    }
    void p1shoot()
    {
        //spawn item saved in payload1 and remove ammo
        if (portSwap == true)
        {
            if (payload1Ammo >= 1)
            {
                    Instantiate(MissilePrefabs[payload1Selector], wPorts[0].position, wPorts[0].rotation);
                    portSwap = false;
                    payload1Ammo--;
                    hasFired = true;
                    audioSource.PlayOneShot(sounds[2]);
            }
        }
        if (portSwap == false)
        {
            if (payload1Ammo >= 1)
            {
                if (hasFired == false)
                {
                    Instantiate(MissilePrefabs[payload1Selector], wPorts[1].position, wPorts[1].rotation);
                    portSwap = true;
                    payload1Ammo--;
                    audioSource.PlayOneShot(sounds[2]);
                }
            }
        }
        hasFired = false;
        //slot 0 skip or set to spawn unlimited dummys
    }
    public void Shoot()
    {
            //add timer
            refireTime = Time.time + nextFire;
            //spawn bullet
            Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation);
    }
    public void TakeDamage(int damage)
    {
        //take damage to shield
        shield -= damage;
        //fail over shield to health
        if (shield < 0) { health += shield; shield = 0; }
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
        //play sound effect
        audioSource.PlayOneShot(sounds[3]);
    }
}