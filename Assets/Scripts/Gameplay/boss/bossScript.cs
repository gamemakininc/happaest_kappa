using Unity.Burst;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    //patrol variables
    public Transform[] movepoints;
    public int tracker;//set to # of movepoints
    public int points;
    public float speed=3;
    //rb because everything has a rb :(
    public Rigidbody2D rb;
    //bullet storage nothing to see here
    public GameObject[] bullets; //0normal, 1aimed, 2laser
    //burst delays
    public float lCoolDown;
    public float gunCooldown;
    public float aimedGunCooldown;
    //gun ports 
    public GameObject[] gunPorts;//0-2streaght, 3-4 aimed, 5-6 laser

    private void Start()
    {
        tracker = movepoints.Length;
        tracker -= 1;
    }
    // Update is called once per frame
    void Update()
    {
        //move to next point
        transform.position = Vector2.MoveTowards(transform.position, movepoints[points].position, speed*Time.deltaTime);
        //are we there yet?
        if (Vector2.Distance(transform.position,movepoints[points].position)<0.1f)
        {
            //pick next point 
            if (points <= tracker) { points++; }
            else { points = 0; }
        }
    }
}
