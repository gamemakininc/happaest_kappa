using UnityEngine;

public class sbosstracker : MonoBehaviour
{
    //array of active thrusters
    public bool[] thrusters;
    public GameObject[] thrusterObj;
    //do not use to calculate health as lasers cant hit thrusters.
    private int thrustIntMax;
    private int thrustIntCurrent;
    private int thCounter;
    //array of active turrets
    public bool[] turrets;
    public GameObject[] laserObj;
    public GameObject[] cannonObj;
    public GameObject[] missileObj;
    //used for health calculation
    private int turretsMax;
    public int turretsCurrent;
    private int tuCounter;
    //swaps
    public int gInputInt;//handel for turret script
    public int tInputInt;//handel for thruster script
    public int swapint;
    private int counter;
    private bool t1Fired;
    private bool t2Fired;

    //weapon timers
    public float thrustTimer;
    public float thrustTimer1;
    public float laserTimer;
    public float cannonTimer;
    public float missileTimer;
    private float t1Start;
    private float t1Stop;
    private float t2Start;
    private float t2Stop;

    //selecter counter
    public int selecterCounter;
    private float lazorCounter;
    //stage trackers
    private bool slow;

    // Start is called before the first frame update 
    void Start()
    {
        thrustIntMax = thrusters.Length;
        thrustIntCurrent = thrustIntMax;
        thCounter = thrustIntMax - 1;
        turretsMax = turrets.Length;
        turretsCurrent = turretsMax;
        tuCounter = turretsMax - 1;
        t1Start = 9.8f;
        t2Start = 9.8f;
        t1Stop = 10.9f;
        t2Stop = 10.9f;
        //gInputInt = 11;
    }
    //update currents
    public void updateVarsThrust()
    {
        //should not count twards health because lasers cant hit them

        //set variable false
        thrusters[tInputInt] = false;
        //reset counter and swap
        counter = 0;
        swapint = 0;
        //loop to update currets
        while (counter < thCounter)
        {
            if (thrusters[counter] == true) { swapint++; }
            counter++;
        }
        if (swapint < thrustIntCurrent) { turretsCurrent = swapint; }
    }
    public void updateVarsTurret()
    {
        //set variable false
        turrets[gInputInt] = false;
        //reset counter and swap
        counter = 0;
        swapint = 0;
        //loop to update currets
        while (counter < tuCounter)
        {
            if (turrets[counter] == true) { swapint++; }
            counter++;
        }
        if (swapint < turretsCurrent) { turretsCurrent = swapint; }
        if (turretsCurrent <= 0) 
        {
            //add score to level score
            ObserverScript.Instance.levelScore += 1000;
            //get wave spawner script refrence
            EnemyWavev2 waveSpner = FindObjectOfType<EnemyWavev2>();
            waveSpner.OnLevelComplete();
            ObserverScript.Instance.type3++;

        }
        Debug.Log("turrets detected: "+ turretsCurrent);
    }
    // Update is called once per frame
    void Update()
    {
        //run timers
        thrustTimer += 1 * Time.deltaTime;
        //before tile stops
        if (slow == false)
        {
            if (thrustTimer >= 5.7)
            {
                //fire thrusters
                thrusterObj[0].GetComponent<thrusterScript>().turnOn();
                thrusterObj[1].GetComponent<thrusterScript>().turnOn();
                thrusterObj[2].GetComponent<thrusterScript>().turnOn();
                thrusterObj[3].GetComponent<thrusterScript>().turnOn();
                thrusterObj[4].GetComponent<thrusterScript>().turnOn();
                thrusterObj[5].GetComponent<thrusterScript>().turnOn();
                //slow tile
                GetComponent<TileScript>().speed += 0.3f * Time.deltaTime;
                //slow faster
                if (thrustTimer >= 6.5)
                {
                    GetComponent<TileScript>().speed += 0.3f * Time.deltaTime;
                }
                //slow faster
                if (thrustTimer >= 7)
                {

                    GetComponent<TileScript>().speed += 0.4f * Time.deltaTime;
                }
                //once stoped
                if (GetComponent<TileScript>().speed >= 0) 
                {
                    //tell tile to freeze
                    GetComponent<TileScript>().bosStop = true;
                    //dissable tile slow moduel
                    slow = true;
                    //stop thuster animation
                    thrusterObj[0].GetComponent<thrusterScript>().turnOff();
                    thrusterObj[1].GetComponent<thrusterScript>().turnOff();
                    thrusterObj[2].GetComponent<thrusterScript>().turnOff();
                    thrusterObj[3].GetComponent<thrusterScript>().turnOff();
                    thrusterObj[4].GetComponent<thrusterScript>().turnOff();
                    thrusterObj[5].GetComponent<thrusterScript>().turnOff();
                }
            }
        }
        else
        {
            //thruster fire
            if (thrusters[0] == true || thrusters[1] == true || thrusters[2] == true)
            {
                if (t1Start <= thrustTimer1)
                {
                    //turn thruster array1 on
                    if (thrusterObj[0] != null) { thrusterObj[0].GetComponent<thrusterScript>().turnOn(); }
                    if (thrusterObj[1] != null) { thrusterObj[1].GetComponent<thrusterScript>().turnOn(); }
                    if (thrusterObj[2] != null) { thrusterObj[2].GetComponent<thrusterScript>().turnOn(); }
                    if (t1Stop <= thrustTimer1)
                    {
                        //turn thrusters off
                        if (thrusterObj[0] != null) { thrusterObj[0].GetComponent<thrusterScript>().turnOff(); }
                        if (thrusterObj[1] != null) { thrusterObj[1].GetComponent<thrusterScript>().turnOff(); }
                        if (thrusterObj[2] != null) { thrusterObj[2].GetComponent<thrusterScript>().turnOff(); }
                        if (thrustTimer > 10)
                        {
                            //build new timer
                            t1Start = Random.Range(3, 5);
                            t1Stop = Random.Range(1, 3) + t1Start;
                            //reset timer
                            thrustTimer1 = 0;
                        }
                    }
                }
            }
            if (thrusters[3] == true || thrusters[4] == true || thrusters[5] == true)
            {
                if (t2Start <= thrustTimer)
                {
                    if (thrusterObj[3] != null) { thrusterObj[3].GetComponent<thrusterScript>().turnOn(); }
                    if (thrusterObj[4] != null) { thrusterObj[4].GetComponent<thrusterScript>().turnOn(); }
                    if (thrusterObj[5] != null) { thrusterObj[5].GetComponent<thrusterScript>().turnOn(); }
                    if (t2Stop <= thrustTimer)
                    {
                        //turn thrusters off
                        if (thrusterObj[3] != null) { thrusterObj[3].GetComponent<thrusterScript>().turnOff(); }
                        if (thrusterObj[4] != null) { thrusterObj[4].GetComponent<thrusterScript>().turnOff(); }
                        if (thrusterObj[5] != null) { thrusterObj[5].GetComponent<thrusterScript>().turnOff(); }
                        if (thrustTimer > 10)
                        {
                            //build new timer
                            t2Start = Random.Range(3, 5);
                            t2Stop = Random.Range(1, 3) + t2Start;
                            //reset timer
                            thrustTimer = 0;
                        }
                    }

                }
            }
        }
        //after tile stops
        if (slow == true)
        {
            //run wepon counters
            missileTimer += 1 * Time.deltaTime;
            cannonTimer += 1 * Time.deltaTime;
            laserTimer += 1 * Time.deltaTime;
            //timer resets
            if (selecterCounter > 9) { selecterCounter = 0; }
            if (cannonTimer > 12) { cannonTimer = 0; }
            if (missileTimer > 10.5) { missileTimer = 0; }
            if (laserTimer > 28.5) { laserTimer = 0; }
            //fire first volly
            if (laserTimer > 3 && laserTimer < 3.5 && laserObj[0] != null) { laserObj[0].GetComponent<turretScript>().fire(); Debug.Log("tried to shoot laz @ " + laserObj[0].transform); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[0] != null) { missileObj[0].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[0] != null) { cannonObj[0].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire second volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[1] != null) { laserObj[1].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[1] != null) { missileObj[1].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[1] != null) { cannonObj[1].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire third volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[2] != null) { laserObj[2].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[2] != null) { missileObj[2].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[2] != null) { cannonObj[2].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire fourth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[3] != null) { laserObj[3].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[3] != null) { missileObj[3].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[3] != null) { cannonObj[3].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire fifth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[4] != null) { laserObj[4].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[4] != null) { missileObj[4].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[4] != null) { cannonObj[4].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire sixth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[5] != null) { laserObj[5].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[5] != null) { missileObj[5].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[5] != null) { cannonObj[5].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire seventh volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[6] != null) { laserObj[6].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[6] != null) { missileObj[6].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[6] != null) { cannonObj[6].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire eaghth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[7] != null) { laserObj[7].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[7] != null) { missileObj[7].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[7] != null) { cannonObj[7].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire nineth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[8] != null) { laserObj[8].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[8] != null) { missileObj[8].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[8] != null) { cannonObj[8].GetComponent<turretScript>().fire(); }
            selecterCounter++;
            lazorCounter += 3;
            //fire tenth volly
            if (laserTimer > lazorCounter && laserTimer < lazorCounter + 0.5 && laserObj[9] != null) { laserObj[9].GetComponent<turretScript>().fire(); }
            if (missileTimer > selecterCounter + 1.5 && missileTimer < selecterCounter + 2 && missileObj[9] != null) { missileObj[9].GetComponent<turretScript>().fire(); }
            if (cannonTimer > selecterCounter + 2 && cannonTimer < selecterCounter + 2.5 && cannonObj[9] != null) { cannonObj[9].GetComponent<turretScript>().fire(); }
        }

    }
}
