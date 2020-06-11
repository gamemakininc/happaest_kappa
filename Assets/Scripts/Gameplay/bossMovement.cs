using UnityEngine;

public class bossMovement : MonoBehaviour
{
    public Transform[] movepoints;
    public int tracker;//set to # of movepoints in editor 
    public int points;
    public float speed=3;
    public float lfireTime;
    public float lCoolDown;
    public Rigidbody2D rb;
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
