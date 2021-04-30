using UnityEngine;

public class bombScript : MonoBehaviour
{
    float speed;
    public Rigidbody2D rb;
    public GameObject flare;
    public SpriteRenderer body;
    public Transform point;
    public float timer;
    float mult;
    bool pop;
    bool die;

    // Start is called before the first frame update
    void Start()
    {
        //get object with tag ("bombspawn"should be the only object in gameplay with this tag)
        point = GameObject.FindGameObjectWithTag("fittingSlot").transform;
        speed = 8;
        mult = .5f;
        //remove parent
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) > .11f)
        {
            //move??
            Vector3 direction = point.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            rb.velocity = transform.up * speed;
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            if (die == false)
            {
                rb.velocity = new Vector2(0, 0);
                timer += Time.deltaTime * mult;
                if (mult > 20) { mult += 1f; }
                else { mult += 2; }
                if (pop == false)
                {
                    //retrigger prevention
                    pop = true;
                    //make body invisible
                    body.color = new Color(1, 1, 1, 0);
                    //enable flare
                    flare.SetActive(true);
                }
                flare.transform.localScale = new Vector3(timer, timer, 0);
                if (flare.transform.localScale.x > 250)
                {
                    die=true;
                    pop = false;
                }
            }
            else
            {
                if (pop == false) 
                {
                    pop = true;
                    timer = 1;
                }
                timer -= Time.deltaTime * 1.5f;
                flare.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timer);
                if ( timer <= 0) 
                {
                    Destroy(gameObject);
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        enemyhealth enemy = hitInfo.GetComponent<enemyhealth>();
        if (enemy != null)
        {
            if (enemy.isBoss == false)
            {
                //damage enemy
                enemy.TakeDamage(10000000);
            }
        }
        PlayerScript ps = hitInfo.GetComponent<PlayerScript>();
        if (ps != null) 
        {
            ps.shield = 0;
        }
    }
}
