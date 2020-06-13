using UnityEngine;

public class bossScript : MonoBehaviour
{
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

    private void Start()
    {
        lCoolDownTimer = lCoolDown;
        gunCooldownTimer = gunCooldown;
        aimedGunCooldownTimer = aimedGunCooldown;
        tracker = movepoints.Length;
        tracker-=2;
    }
    // Update is called once per frame
    void Update()
    {
        //run timers
        lCoolDownTimer -= 1 * Time.deltaTime;
        gunCooldownTimer -= 1 * Time.deltaTime;
        aimedGunCooldownTimer -= 1 * Time.deltaTime;
        gCounter += 1 * Time.deltaTime;
        g2Counter += 1 * Time.deltaTime;
        //move to next point
        transform.position = Vector2.MoveTowards(transform.position, movepoints[points].position, speed*Time.deltaTime);
        //are we there yet?
        if (Vector2.Distance(transform.position,movepoints[points].position)<0.1f)
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
                //reset timer
                gCounter = 0;
            }
            //reset timer
            if (gunCooldownTimer <= -2.5) { gunCooldownTimer = gunCooldown; }

        }
        if (aimedGunCooldownTimer <= 0)
        {
            if (g2Counter >= .1)
            {
                //shoot
                //spawn bullets
                Instantiate(bullets[1], gunPorts[3].position, Quaternion.identity);
                Instantiate(bullets[1], gunPorts[4].position, Quaternion.identity);
                //reset timer
                g2Counter = 0;
            }
            //reset timer 
            if (aimedGunCooldownTimer <= -1.5) { aimedGunCooldownTimer = aimedGunCooldown; }


        }
        if (lCoolDownTimer <= 0)
        {
            //spawn las3rs
            Instantiate(bullets[2], gunPorts[5].position, gunPorts[5].rotation, parent: gunPorts[5]);
            Instantiate(bullets[2], gunPorts[6].position, gunPorts[6].rotation, parent: gunPorts[6]);
            //reset timer 
            lCoolDownTimer = lCoolDown;

        }
    }
}
