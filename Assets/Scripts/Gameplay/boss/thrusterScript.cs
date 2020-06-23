using UnityEngine;

public class thrusterScript : MonoBehaviour
{
    public int location;
    public float health;
    public GameObject flame;
    public GameObject body;
    public sbosstracker bossTracker;



    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { die(); }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //get script
        pbulletscript pbullet = hitInfo.GetComponent<pbulletscript>();
        if (pbullet != null)
        {
            health -= pbullet.GetComponent<pbulletscript>().Damage;
            //remove pbullet
            pbullet.die();
        }
    }
    public void die() 
    {
        //update animator
        body.GetComponent<Animator>().SetBool("broken", true);
        //dissable colliders
        this.GetComponent<Collider2D>().enabled = false;
        flame.GetComponent<Collider2D>().enabled = false;
        //update bosstracker script
        bossTracker.tInputInt = location;
        bossTracker.updateVarsThrust();
        //remove script objects
        Destroy(flame);//not working for some reason
        Destroy(gameObject);


    }
    public void turnOn() 
    {
        //set animation to fire thrusters
        body.GetComponent<Animator>().SetBool("is on", true);
        //enable flare hitbox
        flame.GetComponent<Collider2D>().enabled = true;
    }
    public void turnOff() 
    {
        //set animation to idle thrusters
        body.GetComponent<Animator>().SetBool("is on", false);
        //disable flare hitbox
        flame.GetComponent<Collider2D>().enabled = false;
    }
    
}
