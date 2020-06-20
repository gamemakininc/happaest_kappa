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
    private float thrustTimer;
    private float laserTimer;
    private float cannonTimer;
    private float missileTimer;
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
        selecterCounter = 0;
        //fire first volly
        if (laserTimer >= 1 && laserTimer <= 1.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null) 
        {
            if (laserObj[1] != null || laserObj[2] != null || laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter+1.5 && missileTimer <= selecterCounter+2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null) 
        {
            if (missileObj[1] != null || missileObj[2] != null || missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter+2 && cannonTimer <= selecterCounter+2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null) 
        {
            if (cannonObj[1] != null || cannonObj[2] != null || cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire second volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter+0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if (laserObj[2] != null || laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[2] != null || missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[2] != null || cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire third volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[3] != null || laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[3] != null || missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[3] != null || cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire fourth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[4] != null || laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[4] != null || missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[4] != null || cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire fifth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[5] != null || laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[5] != null || missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[5] != null || cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire sixth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[6] != null || laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[6] != null || missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[6] != null || cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire seventh volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[7] != null || laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[7] != null || missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[7] != null || cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire eaghth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[8] != null || laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[8] != null || missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[8] != null || cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire nineth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if ( laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        {
            if ( missileObj[9] != null || missileObj[10] != null) {/*do nothing*/ }
            else { missileTimer = 0; }
        }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {
            if ( cannonObj[9] != null || cannonObj[10] != null) {/*do nothing*/ }
            else { cannonTimer = 0; }
        }
        selecterCounter++;
        lazorCounter += 3;
        //fire tenth volly
        if (laserTimer >= lazorCounter && laserTimer <= lazorCounter + 0.5 && laserObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (laserObj[selecterCounter] == null)
        {
            if (laserObj[9] != null || laserObj[10] != null) {/*do nothing*/ }
            else { laserTimer = 0; }
        }
        if (missileTimer >= selecterCounter + 1.5 && missileTimer <= selecterCounter + 2 && missileObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (missileObj[selecterCounter] == null)
        { missileTimer = 0; }
        if (cannonTimer >= selecterCounter + 2 && cannonTimer <= selecterCounter + 2.5 && cannonObj[selecterCounter] != null) { laserObj[selecterCounter].GetComponent<turretScript>().fire(); }
        else if (cannonObj[selecterCounter] == null)
        {cannonTimer = 0; }
        selecterCounter++;
        lazorCounter += 3;



    }
}
