using UnityEngine;

public class sboss1TurretCtrl : MonoBehaviour
{
    //array of active turrets
    public GameObject[] laserObj;
    public GameObject[] cannonObj;
    public GameObject[] missileObj;
    //swaps
    public int swapint;

    //weapon timers
    public float laserTimer;
    public float cannonTimer;
    public float missileTimer;

    //selecter counter
    public int selecterCounter;
    private float lazorCounter;
    //stage trackers
    private bool slow;

    // Start is called before the first frame update 
    void Start()
    {
        slow = GetComponent<TileScript>().bosStop;
    }
    //update currents


    // Update is called once per frame
    void Update()
    {

        //after tile stops
        if (slow == true)
        {
            //run wepon counters
            missileTimer += 1 * Time.deltaTime;
            cannonTimer += 1 * Time.deltaTime;
            laserTimer += 1 * Time.deltaTime;
            //timer resets
            if (cannonTimer > 12) { cannonTimer = 0; }
            if (missileTimer > 14) { missileTimer = 0; }
            if (laserTimer > 18.5) { laserTimer = 0; }
            //fire first volly
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
        }
        //check stop
        else 
        {
            slow = GetComponent<TileScript>().bosStop;
        }

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
        cannonObj[0].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[1].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[2].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[3].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[4].GetComponentInParent<enemyhealth>().enabled = true;
        cannonObj[5].GetComponentInParent<enemyhealth>().enabled = true;
        //remove children from tile
        transform.DetachChildren();
    }
}
