using UnityEngine;

public class pbulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float timer;
    public int Damage;
    public bool trackingMouse;
    public bool trackingEnemy;
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (trackingMouse == false && trackingEnemy == false)
        {
            rb.velocity = transform.up * speed;
        }
        if (trackingMouse == true) { timer = -2; }

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
            enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
            //move??
            Vector3 direction = enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90f;
            rb.rotation = angle;
            rb.velocity = transform.up * speed;

        }
        if (trackingMouse==true) 
        {
            //get mouse location
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //set angle twards mouse
            Vector2 direction = new Vector2 (
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
                );
            //go forward
            transform.up = direction;
            rb.velocity = transform.up * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        enemyscript enemy = hitInfo.GetComponent<enemyscript>();
        if (enemy != null)
        {
            //damage enemy
            enemy.TakeDamage(Damage);
            //remove bullet
            Destroy(gameObject);
        }
    }
}
