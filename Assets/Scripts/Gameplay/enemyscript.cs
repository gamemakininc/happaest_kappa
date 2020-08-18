using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(enemyhealth))]
public class enemyscript : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Sprite[] enemyViewmodels;
    //timer
    private float timer;
    public bool shootDissabled;
    public GameObject ebullet;
    public Transform mgport;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, 0);
        startY = transform.position.y;
        startX = transform.position.x;
        cameraBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;

        if (currentState != states.kamikaze || currentState != states.paused)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (currentState == states.kamikaze)
            GetComponent<enemyhealth>().health *= 2;

        storedState = currentState;
        //Debug.Log("currentState = " + currentState);
        if (shootDissabled == false) { timer = Random.Range(-2, 0); }
        if (ObserverScript.Instance.factionId == 0) 
        {
            GetComponent<SpriteRenderer>().sprite = enemyViewmodels[0];
        }
        if (ObserverScript.Instance.factionId == 1)
        {
            GetComponent<SpriteRenderer>().sprite = enemyViewmodels[1];
        }
        if (ObserverScript.Instance.factionId == 2)
        {
            GetComponent<SpriteRenderer>().sprite = enemyViewmodels[2];
        }

    }

    //movement pattern
    public enum states
    {
        straight,
        wavy,
        slide,
        kamikaze,
        sidescroll,
        still,
        paused,
        offcam
    }

    public states currentState;
    public float speed = 1;
    public float waitTime = 3.0f; //Delay for behaviours triggering

    [HideInInspector]
    public int currentTab;
    [HideInInspector]
    public int currentTab2;
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
    public float maxRadians = 1.0f;
    private bool isTargeting = true;

    [Header("Side Scroller Attributes")]
    public Vector2 sideVelocity = new Vector2(0, -1.5f);
    private float cameraBoundX;


    //Paused Attributes
    private Vector2 storedVelocity;
    public states storedState;
    
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
                } else if (isTargeting)
                {
                    rb.velocity = new Vector2(0, 0);
                    Kamikaze();
                    isTargeting = false;
                }
                break;
            case states.sidescroll:
                if (waitTime > 0 && transform.position.x < cameraBoundX)
                {
                    waitTime -= Time.deltaTime;
                    rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                } else if(waitTime <= 0)
                {
                    rb.velocity = sideVelocity;
                }
                break;
            case states.still:
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
        if (shootDissabled == false)
        {
            timer += 1 * Time.fixedDeltaTime;
            if (timer >= 3)
            {
                Instantiate(ebullet, mgport.position, mgport.rotation);
                timer = Random.Range(-3, 0);
            }

        }
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
        rb.velocity = targetDirection * speed;
    }

    private void OnBecameVisible()
    {
        //set tag to enable tracking missiles
        transform.gameObject.tag = "enemy";
        //enabled = true;
        rb.velocity = storedVelocity;
        currentState = storedState;
        if (transform.parent != null)
            transform.parent = null;
    }

    private void OnBecameInvisible()
    {
        //set tag to dissable tracking missiles
        transform.gameObject.tag = "Untagged";

        if (currentState == states.sidescroll)
            return;
        if (currentState != states.offcam)
            storedState = currentState;

        currentState = states.offcam;
        //enabled = false;
    }
}
