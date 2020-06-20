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
    private int turretsCurrent;
    private int tuCounter;
    //
    public int gInputInt;//handel for turret script
    public int tInputInt;//handel for thruster script
    private int swapint;
    private int counter;

    //weapon timers
    public float thrustTimer;
    private float laserTimer;
    private float cannonTimer;
    private float missileTimer;
    private float t1Start;
    private float t1Stop;
    private float t2Start;
    private float t2Stop;
    private bool t1Fired;
    private bool t2Fired;
    //selecter counter
    private int selecterCounter;
    private float lazorCounter;
    // Start is called before the first frame update 

    void Start()
    {
        thrustIntMax = thrusters.Length;
        thrustIntCurrent = thrustIntMax;
        thCounter = thrustIntMax - 1;
        turretsMax = turrets.Length;
        turretsCurrent = turretsMax;
        tuCounter = turretsMax - 1;
        t1Start = 3;
        t2Start = 3;
        t1Stop = 6;
        t2Stop = 6;
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
            //end level trigger
        }
    }
    // Update is called once per frame
    void Update()
    {
        //run timers
        missileTimer += 1 * Time.deltaTime; 
        cannonTimer += 1 * Time.deltaTime; 
        laserTimer += 1 * Time.deltaTime; 
        thrustTimer += 1 * Time.deltaTime;
        //inital thruster fire
        if (t1Start >= thrustTimer) 
        {
            //turn thruster array1 on
            thrusterObj[0].GetComponent<thrusterScript>().turnOn();
            thrusterObj[1].GetComponent<thrusterScript>().turnOn();
            thrusterObj[2].GetComponent<thrusterScript>().turnOn();
            if (t1Stop >= thrustTimer)
            {
                //turn thrusters off
                thrusterObj[0].GetComponent<thrusterScript>().turnOff();
                thrusterObj[1].GetComponent<thrusterScript>().turnOff();
                thrusterObj[2].GetComponent<thrusterScript>().turnOff();
                //build new timer
                t1Start = Random.Range(1, 5);
                t1Stop = Random.Range(1, 5)+t1Start;
                t1Fired = true;
                if (t2Fired == true)
                {
                    //reset timer
                    thrustTimer = 0;
                    //reset fired checks
                    t1Fired = false;
                    t2Fired = false;
                }
            }
        }
        if (t2Start >= thrustTimer)
        {
            thrusterObj[3].GetComponent<thrusterScript>().turnOn();
            thrusterObj[4].GetComponent<thrusterScript>().turnOn();
            thrusterObj[5].GetComponent<thrusterScript>().turnOn();
            if (t1Stop >= thrustTimer)
            {
                //turn thrusters off
                thrusterObj[3].GetComponent<thrusterScript>().turnOff();
                thrusterObj[4].GetComponent<thrusterScript>().turnOff();
                thrusterObj[5].GetComponent<thrusterScript>().turnOff();
                //build new timer
                t2Start = Random.Range(1, 5);
                t2Stop = Random.Range(1, 5) + t1Start;
                t2Fired = true;
                if (t1Fired == true)
                {
                    //reset timer
                    thrustTimer = 0;
                    //reset fired checks
                    t1Fired = false;
                    t2Fired = false;
                }
            }

        }
        //fire first volly
        if (laserTimer >= 1 && laserTimer <= 1.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null) 
        {
            //check if future turrets in the array are not null
            if (laserObj[1] != null || laserObj[2] != null || laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter+1.5 && missileTimer <= selecterCounter+2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if (missileObj[1] != null || missileObj[2] != null || missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter+2 && cannonTimer <= selecterCounter+2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if (cannonObj[1] != null || cannonObj[2] != null || cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire second volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter+0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if (laserObj[2] != null || laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[2] != null || missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[2] != null || cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire third volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire fourth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire fifth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire sixth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire seventh volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[7] != null || laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[7] != null || missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire eaghth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[8] != null || laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[8] != null || missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[8] != null || cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire nineth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( laserObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( missileObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            //check if future turrets in the array are not null
            if ( cannonObj[9] != null ) {/*do nothing*/ }
            //if all future turrets null reset timer
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire tenth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null) { laserTimer = 0; }//reset timer
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null) { missileTimer = 0; }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null) {cannonTimer = 0; }
    }
}
