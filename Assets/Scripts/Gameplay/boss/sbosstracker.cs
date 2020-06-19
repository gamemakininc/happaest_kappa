using UnityEngine;

public class sbosstracker : MonoBehaviour
{
    //array of active thrusters
    public bool[] thrusters;
    //do not use to calculate health as lasers cant hit thrusters.
    private int thrustIntMax;
    private int thrustIntCurrent;
    private int thCounter;
    //array of active turrets
    public bool[] turrets;
    //used for health calculation
    private int turretsMax;
    private int turretsCurrent;
    private int tuCounter;
    //
    public int gInputInt;//handel for turret script
    public int tInputInt;//handel for thruster script
    private int swapint;
    private int counter;
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
        
    }
}
