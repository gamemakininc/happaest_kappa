using UnityEngine;

public class crosshairScript : MonoBehaviour
{
    private Vector3 _target;
    private Vector2 _direction;
    private Rigidbody2D rb;
    public float speed = 2.0f;
    private bool used;
    // Start is called before the first frame update
    void Start()
    {
        //set rb
        rb = GetComponent<Rigidbody2D>();
        //remove if not used for anything
        if (ObserverScript.Instance.defenceMission == true || ObserverScript.Instance.fitSetup[10] == 2 || ObserverScript.Instance.fitSetup[11] == 2) 
        {
            used = true;
        }
        if (used == false) 
        {
            //dis bitch pointless YEET!
            Debug.LogWarning("crosshair yote");
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ObserverScript.Instance.mouseAiming == true)
        {
            if (Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) > .11f)
            {
                _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _target.z = 0;
                _direction = (_target - transform.position).normalized;
                rb.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
            }
            else 
            {
                rb.velocity = new Vector2(0,0);
            }
        }
        else 
        {
            if (inputManedger.Instance.GetButtonDownH("cleft"))
            {//check if left pressed add speed to crosshair object
                rb.velocity = new Vector2(-1*speed, rb.velocity.y);
            }
            else if (inputManedger.Instance.GetButtonDownH("cright"))
            {//check if right pressed add speed to crosshair object
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }
            else //if no button on x axis pressed x speed set to 0
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if (inputManedger.Instance.GetButtonDownH("cup"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 1 * speed);
            }
            else if (inputManedger.Instance.GetButtonDownH("cdown"))
            {
                rb.velocity = new Vector2(rb.velocity.x, -1 * speed);
            }
            else 
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

        }
    }
}
