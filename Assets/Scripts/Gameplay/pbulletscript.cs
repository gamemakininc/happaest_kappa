using UnityEngine;

public class pbulletscript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float timer;
    public int Damage;
    public bool aimed;
    public bool trackingEnemy;
    public bool islasor;
    public Transform Enemy;
    public Transform[] laserBeam;
    public LineRenderer lineRenderer;
    public float laserVisible;
    public bool mouseAiming;


    // Start is called before the first frame update
    void Start()
    {
        if (aimed == false && trackingEnemy == false && islasor == false)
        {
            rb.velocity = transform.up * speed;
        }
        if (aimed == true) 
        { 
            timer = -2;
            mouseAiming = ObserverScript.Instance.mouseAiming;
        }
        if (islasor == false) { lineRenderer = new LineRenderer(); }
        if (islasor == true) { timer = 1.5f; }
        if (islasor == true)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(laserBeam[0].position, laserBeam[0].up);
            if (hitInfo)
            {
                enemyhealth enemy = hitInfo.transform.GetComponent<enemyhealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                    laserBeam[1].position = hitInfo.point;
                }
                else
                {
                    laserBeam[1].position = laserBeam[0].up * 10000;
                }
                lineRenderer.enabled = true;
                laserVisible = 0;
            }
        }

    }
    private void Update() 
    {
        if (islasor == true)
        {
            lineRenderer.SetPosition(0, laserBeam[0].position);
            lineRenderer.SetPosition(1, laserBeam[1].position);
        }
        //incroment timer
        timer += 1.0F * Time.deltaTime;
        //check timer
        if (timer >= 2)
        {
            //destroy game object
            GameObject.Destroy(gameObject);
        }
        //used for 'smart' missiles
        if (trackingEnemy==true) 
        {
            //get object with tag
            Enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
            //move??
            Vector3 direction = Enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90f;
            rb.rotation = angle;
            rb.velocity = transform.up * speed;

        }
        if (aimed == true)
        {//change to track a croshair game object to allow mouse aiming toggle

            //get mouse location
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //set angle twards mouse
            Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
            //go forward
            transform.up = direction;
            rb.velocity = transform.up * speed;
        }
        if (islasor == true)
        {
            if (laserVisible <= 1)
            {
                laserVisible = laserVisible + 1 * Time.deltaTime;
                if (laserVisible >= 0.1f) { lineRenderer.enabled = false; }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        enemyhealth enemy = hitInfo.GetComponent<enemyhealth>();
        if (enemy != null)
        {
            //damage enemy
            enemy.TakeDamage(Damage);
            //remove bullet
            Destroy(gameObject);
        }
    }
    public void die()
    {
        Destroy(gameObject);
    }
}
