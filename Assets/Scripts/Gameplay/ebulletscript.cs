using UnityEngine;

public class ebulletscript : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public float timer;
    public int Damage;
    public bool aimed;
    public bool tracking;
    
    public int value;//score value of enemy
    //tracking
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (aimed == false && tracking == false)
        {
            rb.velocity = transform.up * speed;
        }
        else if (aimed == true)
        {
            //get object with tag
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //move??
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            rb.rotation = angle;
        }
        else if (tracking == true) 
        {
            timer -= 4;
        }
    }
    private void Update() 
    {
        //incroment timer
        timer += 1.0F * Time.deltaTime;
        //check timer
        if (timer >= 4)
        {
            //destroy game object
            //GameObject.Destroy(gameObject);
        }
        if (aimed == true) 
        {
            rb.velocity = transform.up * speed;
        }
        if (tracking == true)
        {
            //get object with tag
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //set rotation
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            //move
            rb.velocity = transform.up * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        pbulletscript pBullet = hitInfo.GetComponent<pbulletscript>();
        if (pBullet != null)
        {
            ObserverScript.Instance.score += value;
            //remove pbullet
            pBullet.die();
            //remove ebullet
            Destroy(gameObject);
        }
        if (player != null)
        {
            //damage enemy
            player.TakeDamage(Damage);
            //remove bullet
            Destroy(gameObject);
        }
    }
    public void die()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
