using UnityEngine;

public class bossScript3 : MonoBehaviour
{
    public GameObject tile;
    //patrol variables
    public Transform[] movepoints;
    public int tracker;//set to # of movepoints
    public int points;
    public float speed;
    //rb because everything has a rb :(
    public Rigidbody2D rb;
    //bullet storage nothing to see here
    public GameObject[] bullets; //0normal, 1aimed, 2laser
    //burst delays
    public float lCoolDown;
    private float lCoolDownTimer;
    public float gunCooldown;
    private float gunCooldownTimer;
    public float aimedGunCooldown;
    private float aimedGunCooldownTimer;
    private float gCounter;
    private float g2Counter;
    //gun ports 
    public Transform[] gunPorts;//0-2streaght, 3-4 aimed, 5-6 laser
    //timer
    float thrustTimer;
    bool slow;

    private void Start()
    {
        lCoolDownTimer = lCoolDown;
        gunCooldownTimer = gunCooldown;
        aimedGunCooldownTimer = aimedGunCooldown;
        tracker = movepoints.Length;
        tracker -= 2;
    }
    // Update is called once per frame
    void Update()
    {
        //before tile stops
        if (slow == false)
        {
            //stop timer
            thrustTimer += 1 * Time.deltaTime;
            if (thrustTimer >= 5.7)
            {
                tile.GetComponent<TileScript>().speed += 0.3f * Time.deltaTime;
                if (thrustTimer >= 6.5)
                {
                    tile.GetComponent<TileScript>().speed += 0.3f * Time.deltaTime;
                }
                if (thrustTimer >= 7)
                {
                    tile.GetComponent<TileScript>().speed += 0.4f * Time.deltaTime;
                }
                //sile stopped
                if (tile.GetComponent<TileScript>().speed >= 0)
                {
                    //set tile speed to 0
                    tile.GetComponent<TileScript>().bosStop = true;
                    //enable hp and shooting
                    GetComponent<enemyhealth>().enabled = true;
                    slow = true;
                }
            }
        }
        //check if stopped
        if (slow == true)
        {
            //run timers
            lCoolDownTimer -= 1 * Time.deltaTime;
            gunCooldownTimer -= 1 * Time.deltaTime;
            aimedGunCooldownTimer -= 1 * Time.deltaTime;
            gCounter += 1 * Time.deltaTime;
            g2Counter += 1 * Time.deltaTime;
        }
        //move to next point
        transform.position = Vector2.MoveTowards(transform.position, movepoints[points].position, speed * Time.deltaTime);
        //are we there yet?
        if (Vector2.Distance(transform.position, movepoints[points].position) < 0.1f)
        {
            //pick next point 
            if (points <= tracker) { points++; }
            else { points = 0; }
        }

        if (gunCooldownTimer <= 0)
        {
            if (gCounter >= .1)
            {
                //spawn bullets
                Instantiate(bullets[0], gunPorts[0].position, gunPorts[0].rotation);
                Instantiate(bullets[0], gunPorts[1].position, gunPorts[1].rotation);
                Instantiate(bullets[0], gunPorts[2].position, gunPorts[2].rotation);
                Instantiate(bullets[0], gunPorts[3].position, gunPorts[3].rotation);
                //reset timer
                gCounter = 0;
            }
            //reset timer
            if (gunCooldownTimer <= -2.5) { gunCooldownTimer = gunCooldown; }

        }
        if (aimedGunCooldownTimer <= 0)
        {
            if (g2Counter >= .2)
            {
                //shoot
                //spawn bullets
                Instantiate(bullets[1], gunPorts[4].position, Quaternion.identity);
                Instantiate(bullets[1], gunPorts[5].position, Quaternion.identity);
                Instantiate(bullets[1], gunPorts[6].position, Quaternion.identity);
                Instantiate(bullets[1], gunPorts[7].position, Quaternion.identity);
                Instantiate(bullets[1], gunPorts[8].position, Quaternion.identity);
                //reset timer
                g2Counter = 0;
            }
            //reset timer 
            if (aimedGunCooldownTimer <= -1.5) { aimedGunCooldownTimer = aimedGunCooldown; }


        }
        if (lCoolDownTimer <= 0)
        {
            //spawn las3rs
            Instantiate(bullets[2], gunPorts[9].position, gunPorts[9].rotation, parent: gunPorts[9]);
            Instantiate(bullets[2], gunPorts[10].position, gunPorts[10].rotation, parent: gunPorts[10]);
            //reset timer 
            lCoolDownTimer = lCoolDown;

        }
    }
}
