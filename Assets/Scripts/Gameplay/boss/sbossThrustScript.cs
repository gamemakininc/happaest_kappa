using UnityEngine;

public class sbossThrustScript : MonoBehaviour
{
    //array of active thrusters
    public GameObject[] thrusterObj;
    //weapon timers
    public float thrustTimer;
    public float thrustTimer1;
    private float t1Start;
    private float t1Stop;
    private float t2Start;
    private float t2Stop;
    //stage trackers
    private bool slow;

    // Start is called before the first frame update 
    void Start()
    {
        t1Start = 9.8f;
        t2Start = 9.8f;
        t1Stop = 10.9f;
        t2Stop = 10.9f;
        //gInputInt = 11;
    }
    //update currents


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
                    transform.DetachChildren();
                    sboss1TurretCtrl sboss1TurretCtrl = GetComponent<sboss1TurretCtrl>();
                    sboss1TurretCtrl.endEnter();
                }
            }
        }
        else
        {
            //thruster fire
            if (thrusterObj[0] != null || thrusterObj[1] != null || thrusterObj[2] != null)
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
            if (thrusterObj[3] != null || thrusterObj[4] != null || thrusterObj[5] != null)
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
    }
}
