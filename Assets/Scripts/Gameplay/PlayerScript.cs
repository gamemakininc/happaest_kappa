using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerScript : MonoBehaviour
{
    //idK
    public inputManedger im;
    Vector2 movement;
    //set health
    public Image hpBar;
    public float maxHealth;
    public float health;
    public float repair;
    //shield and regen
    public Image sBar;
    public float maxShield;
    public float shield;
    public float sRegen = .5f;
    //set death sprite
    public int deathEffectSelector;
    public GameObject[] deathEffect;
    //build bullet 
    public int payload0Selector;
    public int payload1Selector;
    public int payload0Ammo;
    public int payload1Ammo;
    public Transform[] wPorts;
    public GameObject[] BulletPrefabs;
    public GameObject[] MissilePrefabs;
    public int bulletSelector = 1;
    public int mslBonus;
    //set speed
    public float MoveSpeed = 6;
    public float forwardSpeed = 0.7f;
    //set player model
    public Rigidbody2D rb;
    public Animator animator;
    //swap variables
    public float dumbdumb;
    private bool portSwap;
    private bool hasFired = false;
    //timers
    private float hitTimer;
    private float itimer;
    private float fRtimer;
    private float baceRefireRate;
    private float refireTime;
    private float enextFire;
    private float nextFire;
    //audio
    public AudioClip[] sounds;
    public AudioSource audioSource;
    //buff limmiters
    public bool involActive;
    public bool fireBuffActive;
    //viewmodel editors
    public Sprite[] viewmodel;
    public RuntimeAnimatorController[] animationset;
    public int shipselect;
    private void Start()
    {
        //set variables from observer
        maxShield = ObserverScript.Instance.pShield;
        shield = maxShield;
        sRegen = ObserverScript.Instance.pSRegen;
        maxHealth = ObserverScript.Instance.pHealth;
        health = maxHealth;
        repair = ObserverScript.Instance.pRepair;
        MoveSpeed = ObserverScript.Instance.pSpeed;
        bulletSelector = ObserverScript.Instance.pBulletSelector - 1;
        payload0Selector = ObserverScript.Instance.pP0 - 1;
        payload1Selector = ObserverScript.Instance.pP1 - 1;
        mslBonus = ObserverScript.Instance.mslBonus;
        nextFire = ObserverScript.Instance.fireRate;
        enextFire = ObserverScript.Instance.efireRate;
        shipselect = ObserverScript.Instance.fitSetup[13]-1;
        //save location of RB and animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //if variables could not be imported set bace values
        if (health == 0)
        {
            health = 100;
        }
        if (MoveSpeed == 0f) 
        {
            MoveSpeed = 6f;
        }
        //set launcher ammo baced on selectors
        if (payload0Selector == 0){ payload0Ammo = 20 + mslBonus; }
        else if (payload0Selector == 1) { payload0Ammo = 15 + mslBonus; }
        else if (payload0Selector == 2) { payload0Ammo = 10 + mslBonus; }
        if (payload1Selector == 0) { payload0Ammo = 20 + mslBonus; }
        else if (payload1Selector == 1) { payload1Ammo = 15 + mslBonus; }
        else if (payload1Selector == 2) { payload1Ammo = 10 + mslBonus; }
        this.GetComponent<Animator>().runtimeAnimatorController = animationset[shipselect];
        this.GetComponent<SpriteRenderer>().sprite = viewmodel[shipselect];
        im = FindObjectOfType<inputManedger>();

    }

    //Update called once per frame
    private void Update()
    {
        //input
        //left right
        movement.x = im.getAxis("Horizontal");
        movement.y = im.getAxis("Vertical");
        //fire gun
        if (im.GetButtonDown("fire1") && Time.time > refireTime)
        {
            Shoot();
            //check bullet selector for what sound to play
            if (bulletSelector == 2) { audioSource.PlayOneShot(sounds[0]); }
            else if (bulletSelector ==0 ) { audioSource.PlayOneShot(sounds[1]); }
            else if (bulletSelector == 1) { audioSource.PlayOneShot(sounds[1]); }
            else if (bulletSelector == 3) { audioSource.PlayOneShot(sounds[4]); }
            else if (bulletSelector == 4) { audioSource.PlayOneShot(sounds[4]); }
            else if (bulletSelector == 5) { audioSource.PlayOneShot(sounds[4]); }
        }
        //fire missile slot1
        if (im.GetButtonDown("fire2"))
        {
            p0shoot();
        }
        //fire missile slot2
        if (im.GetButtonDown("fire3"))
        {
            p1shoot();
        }

        //animator variables
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //hp regen (check if hp below max)
        if (health < maxHealth)
        { 
            health += repair * Time.deltaTime;
        }
        //check if shield can regen(& has been long enough since last hit)
        if (shield < maxShield && hitTimer>=2)
        {//shield regen
            shield += sRegen * Time.deltaTime;
        }
        if (involActive == true)
        {//incroment timer
            itimer += 1.0F * Time.deltaTime;
            if (itimer >= 7) { involActive = false; }
        }
        if (fireBuffActive == true)
        {//incroment timer
            fRtimer += 1.0F * Time.deltaTime;
            //after some time dissable
            if (fRtimer >= 7) 
            {   fireBuffActive = false;
                //reset fire rate
                nextFire = baceRefireRate;
            }
        }
        //incroment timer (used for shield regen delay)
        hitTimer += 1.0F * Time.deltaTime;
        if (maxShield < 1) { sBar.fillAmount = 0f; }
        else if (maxShield > 1) { sBar.fillAmount = shield/maxShield; }
        hpBar.fillAmount = health/maxHealth;
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
    }
    public void Shoot()
    {
            //fire rate augments
            if (bulletSelector == 0 || bulletSelector == 1)
            { //spawn bullet
                Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation);
                //reset timer
                refireTime = Time.time + nextFire;
            }
            if (bulletSelector == 2)
            {//spawn bullet
                Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation);
                //reset timer
                refireTime = Time.time + nextFire + 0.1f;
            }

            if (bulletSelector == 3 || bulletSelector == 4)
            { //spawn bullet
                Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation);
                //reset timer
                refireTime = Time.time + enextFire;
            }
            if (bulletSelector == 5)
            { //spawn bullet
                Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation);
                //reset timer
                refireTime = Time.time + enextFire + 0.1f;
            }
        //lasers only equipable to the secrit ships
        if (bulletSelector == 6) 
        {//spawn laser
            Instantiate(BulletPrefabs[bulletSelector], wPorts[2].position, wPorts[2].rotation, parent: wPorts[2]);
            refireTime = Time.time + 0.1f;
        }
        if (bulletSelector == 7)
        {//spawn laser
            Instantiate(BulletPrefabs[6], wPorts[0].position, wPorts[0].rotation, parent: wPorts[0]);
            Instantiate(BulletPrefabs[6], wPorts[1].position, wPorts[1].rotation, parent: wPorts[1]);
            refireTime = Time.time + 0.1f;
        }

    }
    public void TakeDamage(float damage)
    {
        hitTimer = 0;
        if (involActive == false)
        {
            //take damage to shield
            shield -= damage;
            //fail over shield to health
            if (shield < 0) { health += shield; shield = 0; }

        }
        else if (involActive == true) { dumbdumb -= damage; }
        //check health
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (deathEffect[shipselect] != null)
        {
            //spawn death sprite
            Instantiate(deathEffect[shipselect], transform.position, Quaternion.Euler(0, 0, -90));
        }
        //remove self
        Destroy(gameObject);
        //play sound effect
        audioSource.PlayOneShot(sounds[3]);
    }
    public void invincibility()
    {
        itimer = 0;
        //dissable damage
        involActive =true;
        //add post processing effect
    }
    public void fireBuff() 
    {
        //reset timer
        fRtimer = 0;
        //dissable ability to pickup another similer buff
        fireBuffActive = true;
        //get bace fire rate in swapfile
        baceRefireRate = nextFire;
        //set fire delay to 0
        nextFire = 0;
    }
    public void addMissiles() 
    {
        //add missiles to all active missile slots
        if (payload0Selector>=0) { payload0Ammo += 5; }
        if (payload1Selector>=0) { payload1Ammo += 5; }
    }
}