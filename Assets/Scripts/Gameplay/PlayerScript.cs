﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerScript : MonoBehaviour
{
    //idK
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
    //build bullet 
    public int payload0Ammo;
    public int payload1Ammo;
    public Transform[] wPorts;
    public GameObject BulletPrefab;
    public GameObject MissilePrefab1;
    public GameObject MissilePrefab2;
    //set speed
    public float MoveSpeed = 6;
    public float forwardSpeed = 0.7f;
    //set player model
    public Rigidbody2D rb;
    public Animator animator;
    //swap variables
    public GameObject es;
    public float dumbdumb;
    private bool portSwap;
    private bool hasFired = false;
    //timers
    public float blinkCharger;
    private float hitTimer;
    private float itimer;
    private float fRtimer;
    public float baceRefireRate;
    private float refireTime;
    public float nextFire;
    //audio
    public AudioClip[] sounds;
    public AudioSource audioSource;
    //buff limmiters
    public bool involActive;
    public bool fireBuffActive;
    //viewmodel editors
    public Sprite viewmodel;
    public RuntimeAnimatorController animationset;
    //effects
    public GameObject blinkEffect;
    //set death sprite
    public int deathEffectSelector;
    public GameObject deathEffect;
    //bombs avalible
    public int bomb;

    private void Start()
    {
        shield = maxShield;
        health = maxHealth;
        //save location of RB, animator and sfx audio player
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //set volume
        audioSource.volume = ObserverScript.Instance.sfxvol;
    }

    //Update called once per frame
    private void Update()
    {
        //input
        //left right
        movement.x = inputManedger.Instance.getAxis("Horizontal");
        movement.y = inputManedger.Instance.getAxis("Vertical");
        //fire gun
        if (inputManedger.Instance.GetButtonDownH("fire1") && Time.time > refireTime)
        {
            Shoot();
            //play gun sfx
            audioSource.PlayOneShot(sounds[0]);
        }
        //fire missile slot1
        if (inputManedger.Instance.GetButtonDown("fire2"))
        {
            p0shoot();
        }
        //fire missile slot2
        if (inputManedger.Instance.GetButtonDown("fire3"))
        {
            p1shoot();
        }
        if (inputManedger.Instance.GetButtonDown("blink")) 
        {
            blink(blinkCharger);
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
                //reset fire rates
                nextFire = baceRefireRate;
            }
        }
        //incroment timer (used for shield regen delay)
        hitTimer += 1.0F * Time.deltaTime;
        if (maxShield < 1) { sBar.fillAmount = 0f; }
        else if (maxShield > 1) { sBar.fillAmount = shield/maxShield; }
        hpBar.fillAmount = health/maxHealth;
        //blink charge 
        if (blinkCharger < 1) 
        {
            blinkCharger += .2f * Time.deltaTime;
        }
    }

    //physics tick baced  
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
                    Instantiate(MissilePrefab1, wPorts[0].position, wPorts[0].rotation);
                    portSwap = false;
                    payload0Ammo--;
                    hasFired = true;
                    audioSource.PlayOneShot(sounds[1]);
            }
        }
        if (portSwap == false)
        {
            if (payload0Ammo >= 1)
            {
                if (hasFired == false)
                {
                    Instantiate(MissilePrefab1, wPorts[1].position, wPorts[1].rotation);
                    portSwap = true;
                    payload0Ammo--;
                    audioSource.PlayOneShot(sounds[1]);
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
                    Instantiate(MissilePrefab2, wPorts[0].position, wPorts[0].rotation);
                    portSwap = false;
                    payload1Ammo--;
                    hasFired = true;
                    audioSource.PlayOneShot(sounds[1]);
            }
        }
        if (portSwap == false)
        {
            if (payload1Ammo >= 1)
            {
                if (hasFired == false)
                {
                    Instantiate(MissilePrefab2, wPorts[1].position, wPorts[1].rotation);
                    portSwap = true;
                    payload1Ammo--;
                    audioSource.PlayOneShot(sounds[1]);
                }
            }
        }
        hasFired = false;
    }
    public void Shoot()
    {
        int bs;
        bs = ObserverScript.Instance.fitSetup[12];
        //lasers only equipable to the secrit ships
        if (bs == 7) 
        {//spawn laser
            Instantiate(BulletPrefab, wPorts[2].position, wPorts[2].rotation, parent: wPorts[2]);
            refireTime = Time.time + 0.1f;
        }
        else if (bs == 8)
        {//spawn lasers
            Instantiate(BulletPrefab, wPorts[0].position, wPorts[0].rotation, parent: wPorts[0]);
            Instantiate(BulletPrefab, wPorts[1].position, wPorts[1].rotation, parent: wPorts[1]);
            refireTime = Time.time + 0.1f;
        }
        else
        { //spawn bullet
            Instantiate(BulletPrefab, wPorts[2].position, wPorts[2].rotation);
            //reset timer
            refireTime = Time.time + nextFire;
        }
    }
    void blink(float charge) 
    {
        //distance variables
        float x;
        float y;
        float z;
        //destination
        Vector3 D;

        
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        D = new Vector3(x, y, z);
        Instantiate(blinkEffect, D,Quaternion.identity);
        if (inputManedger.Instance.Vertical>0) { y += charge * 4; }
        if (inputManedger.Instance.Vertical<0) { y += charge * -4; }
        if (inputManedger.Instance.Horizontal>0) { x += charge * 4; }
        if (inputManedger.Instance.Horizontal<0) { x += charge * -4; }
        

        D = new Vector3(x, y, z);
        transform.position = D;
        Instantiate(blinkEffect, D, Quaternion.identity);
        blinkCharger = 0;
    }
    public void TakeDamage(float damage)
    {
        GameObject.Find("PostProcessing Volume").GetComponent<GlitchShaderVariables>()._AddGlitch(0.3f, 0.5f, 0.0f, 0.1f);
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
        if (deathEffect != null)
        {
            //spawn death sprite
            Instantiate(deathEffect, transform.position, Quaternion.Euler(0, 0, -90));
        }
        //notify end screen
        //es.GetComponent<endScreenScript>().win = false;
        //enable end screen
        //es.SetActive(true);
        //remove self
        Destroy(gameObject);
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
        payload0Ammo += 5;
        payload1Ammo += 5; 

    }
}