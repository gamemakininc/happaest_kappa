using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;

public class sBoss3TurretCtrl : MonoBehaviour
{
    //weapons
    //array of active turrets
    public GameObject[] laserObj;
    public GameObject[] cannonObj;
    public GameObject[] missileObj;
    //set top to botum
    public GameObject[] lazPorts;
    //group my sade
    public GameObject[] gunports;

    //bullets
    public GameObject laser;
    public GameObject[] bullets;//0 aimed 1 streaght.
    
    //swaps
    public int swapint;
    int lPatern;
    float lFireTime;
    float gStartTime;
    float gEndTime;
    public bool bwamp;
    bool tguns;
    bool bguns;

    //weapon timers
    public float laserTimer;
    public float cannonTimer;
    public float missileTimer;
    public float sLaserTimer;
    public float sGunTimer;

    //selecter counter used for turret offsets
    private float lazorCounter;
    //stage trackers 
    private bool slow; //used to check if stoped

    // Start is called before the first frame update 
    void Start()
    {
        slow = GetComponent<TileScript>().anotherStopBool;
    }
    //update currents


    // Update is called once per frame
    void Update()
    {
        if (slow != GetComponent<TileScript>().anotherStopBool)
        {
            slow = GetComponent<TileScript>().anotherStopBool;
        }
        //after tile stops
        if (slow == true)
        {
            //run wepon counters
            missileTimer += 1 * Time.deltaTime;
            cannonTimer += 1 * Time.deltaTime;
            laserTimer += 1 * Time.deltaTime;
            sLaserTimer += 1 * Time.deltaTime;
            sGunTimer += 1 * Time.deltaTime;
            //timer resets
            if (cannonTimer > 12) { cannonTimer = 0; }
            if (missileTimer > 14) { missileTimer = 0; }
            if (laserTimer > 18.5) { laserTimer = 0; }
            if (sLaserTimer > 30) 
            {
                //reset retrigger bool
                bwamp = false;
                int swapI= lPatern;
                //reset timer
                sLaserTimer = 0;
                //pick start time
                lFireTime = Random.Range(15f, 29f);
                //pick fire pattern
                lPatern = Random.Range(0, 4);
                //keep from triggering same patturn twice in a row
                if (lPatern == swapI) 
                {
                    //if last value deincrament
                    if (lPatern >= 4) { lPatern--; }
                    //else incroment
                    else { lPatern++; }
                }
            }
            if (sGunTimer > 15) 
            {
                //reset timer
                sGunTimer = 0;
                //pick start point
                gStartTime = Random.Range(5, 10);
                //pick end point
                gEndTime = Random.Range(10, 15);
            }

            //fire first volly ('volly' is wrong word)
            if (laserTimer > 3 && laserTimer < 3.5 && laserObj[0] != null) { laserObj[0].GetComponent<turretScript>().fire(); Debug.Log("tried to shoot laz @ " + laserObj[0].transform); }
            if (missileTimer > 0 + 1.5 && missileTimer < 0 + 2 && missileObj[0] != null) { missileObj[0].GetComponent<turretScript>().fire(); }
            if (cannonTimer > 0 + 2 && cannonTimer < 0 + 2.5 && cannonObj[0] != null) { cannonObj[0].GetComponent<turretScript>().fire(); }
            lazorCounter += 3;
            //fire second volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[1] != null) { laserObj[1].GetComponent<turretScript>().fire(); }
            if (missileTimer > 1 + 1.5 && missileTimer < 1 + 2 && missileObj[1] != null) { missileObj[1].GetComponent<turretScript>().fire(); }
            if (cannonTimer > 1 + 2 && cannonTimer < 1 + 2.5 && cannonObj[1] != null) { cannonObj[1].GetComponent<turretScript>().fire(); }
            lazorCounter += 3;
            //fire third volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[2] != null) { laserObj[2].GetComponent<turretScript>().fire(); }
            if (missileTimer > 2 + 1.5 && missileTimer < 2 + 2 && missileObj[2] != null) { missileObj[2].GetComponent<turretScript>().fire(); }
            if (cannonTimer > 2 + 2 && cannonTimer < 2 + 2.5 && cannonObj[2] != null) { cannonObj[2].GetComponent<turretScript>().fire(); }
            lazorCounter += 3;
            //fire fourth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[3] != null) { laserObj[3].GetComponent<turretScript>().fire(); }
            if (missileTimer > 3 + 1.5 && missileTimer < 3 + 2 && missileObj[3] != null) { missileObj[3].GetComponent<turretScript>().fire(); }
            if (cannonTimer > 3 + 2 && cannonTimer < 3 + 2.5 && cannonObj[3] != null) { cannonObj[3].GetComponent<turretScript>().fire(); }
            lazorCounter += 3;
            //fire fifth volly
            if (missileTimer > 4 + 1.5 && missileTimer < 4 + 2 && missileObj[4] != null) { missileObj[4].GetComponent<turretScript>().fire(); }

            //fire sixth volly
            if (missileTimer > 5 + 1.5 && missileTimer < 5 + 2 && missileObj[5] != null) { missileObj[5].GetComponent<turretScript>().fire(); }

            //laser array fire
            if (lFireTime > sLaserTimer&& lFireTime-1 < sLaserTimer && bwamp==false)
            {
                bwamp = true;
                switch (lPatern)
                {
                    case 0:
                        StartCoroutine(bottumUp());
                        break;
                    case 1:
                        StartCoroutine(topDown());
                        break;
                    case 2:
                        StartCoroutine(crissCross());
                        break;
                    case 3:
                        StartCoroutine(vuamp());
                        break;
                    case 4:
                        StartCoroutine(pmauv());
                        break;
                }
            }
            //gun ports fire
            if (sGunTimer> gStartTime && sGunTimer< gEndTime) 
            {
                if (tguns==false) 
                {
                    Debug.Log("GF part A Top");
                    tguns = true;
                    StartCoroutine(gunfire(0, 1));
                    StartCoroutine(gunfire(1, 1));
                    StartCoroutine(gunfire(2, 1));
                    StartCoroutine(gunfire(3, 1));
                }
                else if (bguns == false) 
                {
                    Debug.Log("GF part A Bottum");
                    bguns = true;
                    StartCoroutine(gunfire(4, 0));
                    StartCoroutine(gunfire(5, 0));
                    StartCoroutine(gunfire(6, 0));
                    StartCoroutine(gunfire(7, 0));
                }
            }
        }
        //check stop
        else
        {
            slow = GetComponent<TileScript>().anotherStopBool;
        }

    }
    //this doesent need to be an enumerator
    IEnumerator gunfire(int port, int bullet) 
    {
        Debug.Log("GF part B " + port);
        while (sGunTimer > gStartTime && sGunTimer < gEndTime) 
        {
            //getting tiered of makeing the 'spawn so and so' comment
            Instantiate(bullets[bullet], gunports[port].transform);
            //wait
            yield return new WaitForSeconds(0.1f);
            //hammer time
        }
        //reset retrigger prevention
        if (port >= 0 && port <= 3 && tguns == true) { tguns = false; }
        else if (port>=4&&port<=7&&bguns==true) { bguns = false; }
        //idk why this is here but it seems to be helping
        yield return 0;
    }
    IEnumerator bottumUp() 
    {
        Debug.Log("bottumUp");
        int I = 19;
        while (I >= 0) 
        {
            //spawn laser 
            Instantiate(laser,lazPorts[I].transform);
            //wait
            yield return new WaitForSeconds(0.1f);
            //deincriment 'I' for next iteration
            I--;
        }
        yield return new WaitForSeconds(6f);
        yield return 0; 
    }
    IEnumerator topDown()
    {
        Debug.Log("topDown");
        int I = 0;
        while (I <= 19)
        {
            //spawn laser 
            Instantiate(laser, lazPorts[I].transform);
            //wait
            yield return new WaitForSeconds(0.1f);
            //incriment 'I' for next iteration
            I++;
        }
        yield return new WaitForSeconds(6f);
        yield return 0;
    }
    IEnumerator crissCross()
    {
        Debug.Log("crissCross");
        int I = 19;
        int s1 = I;
        int s2 = 0;
        bool B = false;
        while (I >= 0)
        {
            if (B == false)
            {
                //spawn laser 
                Instantiate(laser, lazPorts[s1].transform);
                //deincroment s1
                s1--;
                s1--;
                //swap the bool
                B = true;
            }
            else 
            {
                //spawn laser 
                Instantiate(laser, lazPorts[s2].transform);
                //increment s2
                s2++;
                s2++;
                //swap the bool
                B = false;
            }

            //wait
            yield return new WaitForSeconds(0.1f);
            //deincriment 'I' for next iteration
            I--;
        }
        yield return new WaitForSeconds(6f);
        yield return 0;
        //tell code this cycle is done
    }
    IEnumerator vuamp()
    {
        Debug.Log("vuamp");
        int I = 10;
        int s1 = 9;
        int s2 = 10;
        while (I > 0)
        {
                //spawn laser 
                Instantiate(laser, lazPorts[s1].transform);
                //deincroment s1
                s1--;
                //spawn laser 
                Instantiate(laser, lazPorts[s2].transform);
                //increment s2
                s2++;

            //wait
            yield return new WaitForSeconds(0.1f);
            //deincriment 'I' for next iteration
            I--;
        }//should spawn first and last and move inward
        yield return new WaitForSeconds(6f);
        yield return 0;
    }
    IEnumerator pmauv()
    {
        Debug.Log("pmauv");
        int I = 10;
        int s1 = 9;
        int s2 = 10;
        while (I >= 0)
        {
            //spawn laser 
            Instantiate(laser, lazPorts[s1].transform);
            //deincroment s1
            s1--;
            //spawn laser 
            Instantiate(laser, lazPorts[s2].transform);
            //increment s2
            s2++;

            //wait
            yield return new WaitForSeconds(0.1f);
            //deincriment 'I' for next iteration
            I--;
        }//should spawn middle and move outward
        yield return new WaitForSeconds(6f);
        yield return 0;
    }
    public void endEnter()
    {
        //enable damage on laser turrets
        laserObj[0].GetComponentInParent<enemyhealth>().enabled = true;
        laserObj[1].GetComponentInParent<enemyhealth>().enabled = true;
        laserObj[2].GetComponentInParent<enemyhealth>().enabled = true;
        laserObj[3].GetComponentInParent<enemyhealth>().enabled = true;
        //enable damage on cannon turrets
        cannonObj[0].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[1].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[2].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[3].GetComponentInParent<enemyhealth>().enabled = true;
        //enable damage on missile turrets
        missileObj[0].GetComponentInParent<enemyhealth>().enabled = true;
        missileObj[1].GetComponentInParent<enemyhealth>().enabled = true;
        missileObj[2].GetComponentInParent<enemyhealth>().enabled = true;
        missileObj[3].GetComponentInParent<enemyhealth>().enabled = true;
        missileObj[4].GetComponentInParent<enemyhealth>().enabled = true;
        missileObj[5].GetComponentInParent<enemyhealth>().enabled = true;
        //remove children from tile
        transform.DetachChildren();

        //reset scale on static ports
        //gunports
        gunports[0].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[1].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[2].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[3].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[4].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[5].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[6].transform.localScale = new Vector3(0.7f, 1, 1);
        gunports[7].transform.localScale = new Vector3(0.7f, 1, 1);
    }

}
