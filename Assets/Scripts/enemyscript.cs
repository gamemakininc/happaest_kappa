using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemyscript : MonoBehaviour
{
    //set health
    public int health = 100;
    //set death sprite
    public GameObject deathEffect;
    private Rigidbody2D rb;
    //loot table var
    public powerupHandeler thisPowerup;

    void Start()
    {
        thisPowerup = GetComponent<powerupHandeler>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, 0);
        startY = transform.position.y;
        startX = transform.position.x;

        if (currentState != states.kamikaze || currentState != states.paused)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (currentState == states.kamikaze)
            health *= 4;

        storedState = currentState;
        //Debug.Log("currentState = " + currentState);
    }

    //movement pattern
    public enum states
    {
        straight,
        wavy,
        slide,
        kamikaze,
        paused,
        offcam
    }

    public states currentState;
    public float speed = 1;
    public float waitTime = 3.0f; //Delay for behaviours triggering

    [HideInInspector]
    public int currentTab;
    [HideInInspector]
    public string currentField;

    [Header("Wavy Attributes")]
    public float amplitude = 1;
    public float period = 0.3f;
    public float yChange = 0.1f; //Obsolete
    private float newX; //Obsolete
    private float newY;
    private float startY;
    private float startX;

    [Header("Slide Attributes")]
    public float slideTime = 2.0f;
    public bool moveRight;

    [Header("Kamikaze Attributes")]
    private bool isTargeting = true;
    public float maxRadians = 1.0f;

    //Paused Attributes
    private Vector2 storedVelocity;
    private states storedState;

    //handel for bullet script
    public void TakeDamage(int damage)
    {
        health -= damage;
        //check health
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //spawn death sprite
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        makeLoot();
        //remove self
        Destroy(gameObject);
    }
    void makeLoot()
    {
        if (thisPowerup != null)
        {
            thisPowerup.dropCalcultation();
        }
        //remove self
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if player/get player script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            //damage player
            player.TakeDamage(health);
            //remove enemy
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        //Restores velocity when unpausing
        if (currentState != states.paused && storedVelocity != Vector2.zero)
            rb.velocity = storedVelocity;

        //Check method of movement
        #region CurrentState
        switch (currentState)
        {
            case states.straight:
                rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                break;
            case states.wavy:
                if (waitTime > Mathf.Infinity) //doesn't really work with wavy
                {
                    waitTime -= Time.deltaTime;
                    rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                }
                else
                {
                    newX = transform.position.x/* - yChange*/;
                    newY = amplitude * Mathf.Sin(period * (newX - startX)) + startY;
                    
                    Vector2 tempPosition = new Vector2(transform.position.x, newY);
                    transform.position = tempPosition;
                    rb.velocity = transform.InverseTransformDirection(new Vector2(rb.velocity.x, -speed));
                }
                break;
            case states.slide:
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                }
                else
                {
                    if (slideTime > 0)
                    {
                        waitTime -= Time.deltaTime;
                        if (moveRight)
                            rb.velocity = transform.InverseTransformDirection(new Vector2(speed * 1.5f, -speed));
                        else
                            rb.velocity = transform.InverseTransformDirection(new Vector2(-speed * 1.5f, -speed));
                    }
                    else
                    {
                        rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                    }
                }
                break;
            case states.kamikaze:
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                }
                else if (isTargeting)
                {
                    rb.velocity = new Vector2(0, 0);
                    Kamikaze();
                    isTargeting = false;
                }
                break;
            case states.paused:
                if (storedVelocity == Vector2.zero)
                    storedVelocity = rb.velocity;
                rb.velocity = Vector2.zero;
                break;
            case states.offcam:
                break;
            default:
                break;
        }
        #endregion
    }

    void Kamikaze()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 targetDirection = (playerPos - transform.position).normalized;
        //Vector3 newDirection = Vector3.RotateTowards(transform.up, targetDirection, maxRadians, 0.0f);
        //float angleDif = Vector3.Angle(transform.up, newDirection);
        Vector3 direction = playerPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.velocity = targetDirection;
    }

    private void OnBecameVisible()
    {
        //enabled = true;
        rb.velocity = storedVelocity;
        currentState = storedState;
        if (transform.parent != null)
            transform.parent = null;
    }

    private void OnBecameInvisible()
    {
        if(currentState != states.offcam)
            storedState = currentState;

        currentState = states.offcam;
        //enabled = false;
    }
}
