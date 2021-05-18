using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(enemyhealth))]
public class enemyscript : MonoBehaviour
{
    float RDtimer;
    int facID;
    private Rigidbody2D rb;
    public Sprite[] enemyViewmodels;
    //timer
    private float timer;
    public bool shootDissabled;
    public GameObject ebullet;
    public Transform mgport;
    //swap
    private int type;

    void Start()
    {
        facID = ObserverScript.Instance.factionId;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, 0);
        startY = transform.position.y;
        startX = transform.position.x;
        cameraBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;

        if (currentState != states.kamikaze || currentState != states.paused)
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        // if suicider and FV double health
        if (currentState == states.kamikaze)
        {
            if (facID == 1||facID==0)
            {
                GetComponent<enemyhealth>().health *= 2;
            }
        }

        storedState = currentState;

        if (currentState == states.slide && transform.position.y < 0)
        {
            //slide left
            moveRight = false;
        }
        else if (currentState == states.slide && transform.position.y > 0) 
        {
            //slide right
            moveRight = true;
        }
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
        if (ObserverScript.Instance.factionId == 3)
        {
            GetComponent<SpriteRenderer>().sprite = enemyViewmodels[3];
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
                type = 0;
                rb.velocity = transform.InverseTransformDirection(new Vector2(0, -speed));
                break;
            case states.wavy:
                type = 1;
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
                type = 2;
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
                type = 3;
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
        rb.velocity = targetDirection * (speed*4);
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
        if (currentState == states.offcam)
            return;

        storedState = currentState;
        currentState = states.offcam;
        //enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if offscrean left
        if (hitInfo.name == "EdgeL")
        {
            //start the kill timer
            GetComponent<autoclear>().enabled = true;
            //check ship type
            if (type == 0)
            {
                //tell spawner script what ship got away
                Camera.main.GetComponent<EnemyWavev2>().lostS++;
            }
            else if (type == 1) 
            {
                Camera.main.GetComponent<EnemyWavev2>().lostW++;
            }
            else if (type == 2) 
            {
                Camera.main.GetComponent<EnemyWavev2>().lostD++;
            }
            else if (type == 3) 
            {
                Camera.main.GetComponent<EnemyWavev2>().lostK++;
            }
        }
    }
    public void Update()
    {
        //only trigger on TL0 ships
        if (facID == 0) 
        {
            //increment timer
            RDtimer += Time.deltaTime * 1;
            if (RDtimer > 5) 
            {
                //after threashold run RNG check
                int bewm = Random.Range(1, 100);
                //if check passes
                if (bewm <= 5)
                {
                    //kill enemy in a way that credits player
                    GetComponent<enemyhealth>().health = 0;
                }
                //if check fails
                else 
                {
                    //reset timer
                    RDtimer = 0;
                }
            }
        }
    }
}
