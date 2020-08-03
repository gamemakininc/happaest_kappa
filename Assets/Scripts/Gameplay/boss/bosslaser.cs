using UnityEngine;

public class bosslaser : MonoBehaviour
{

    public Gradient[] colors;
    public Transform[] laserBeam;
    public LineRenderer fireBeam;
    public float damageTimer;
    public float chargeTimer;
    private float hitTimer;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        //set default values
        fireBeam.enabled = true;
        damageTimer = 0;
        chargeTimer=0;
    }

    // Update is called once per frame 
    void Update()
    {
        //incroment hit timer
        hitTimer += 0.3f * Time.deltaTime;
        //update lasors start and end points
        fireBeam.SetPosition(0, laserBeam[0].position);
        fireBeam.SetPosition(1, laserBeam[1].position);

        if (chargeTimer <= 0.21)
        {
            //set color to charge
            fireBeam.colorGradient = colors[0];
            chargeTimer += 0.08f * Time.deltaTime;
            if (chargeTimer <= 0.17f) { fireBeam.widthMultiplier = chargeTimer; }
            if (chargeTimer >= 0.17 && chargeTimer <= 0.18) { fireBeam.enabled = false; }
        }
        if (chargeTimer >= 0.18 && damageTimer < 1)
        {
            //incroment damage timer
            damageTimer += 0.2f * Time.deltaTime;
            //set color to damage
            fireBeam.colorGradient = colors[1];
            //enable damage beam
            fireBeam.enabled = true;
            
            RaycastHit2D hitInfo = Physics2D.Raycast(laserBeam[0].position, laserBeam[0].right*50);
            if (hitInfo)
            {
                //Debug.DrawRay(laserBeam[0].position, laserBeam[0].right*50, Color.blue);
                PlayerScript Player = hitInfo.transform.GetComponent<PlayerScript>();
                //Debug.Log("hit something: "+ hitInfo.transform);
                if (Player != null)
                {
                    if (hitTimer >= 0.2)
                    {
                        Player.TakeDamage(Damage);
                        hitTimer = 0;
                    }
                }
            }
        }
        if (damageTimer >= 1) { Destroy(gameObject); }
    }

}
