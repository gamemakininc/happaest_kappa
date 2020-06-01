using UnityEngine;

public class ebulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float timer;
    public int Damage;
    public bool trackingEnemy;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
            if (trackingEnemy == false)
            {
            rb.velocity = transform.up * speed;
            }
    }
    private void Update() 
    {
        //incroment timer
        timer += 1.0F * Time.deltaTime;
        //check timer
        if (timer >= 2)
        {
            //destroy game object
            GameObject.Destroy(gameObject);
        }
        if (trackingEnemy==true) 
        {
            //get object with tag
            player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
            //move??
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90f;
            rb.rotation = angle;
            rb.velocity = transform.up * speed;

        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            //damage enemy
            player.TakeDamage(Damage);
            //remove bullet
            Destroy(gameObject);
        }
    }
}
