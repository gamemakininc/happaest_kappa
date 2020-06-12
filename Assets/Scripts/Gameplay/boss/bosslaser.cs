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
        GetComponent<Collider2D>().enabled = false;
        damageTimer = 0;
        chargeTimer=0;
    }

    // Update is called once per frame 
    void Update()
    {
        //incroment hit timer
        hitTimer += 1 * Time.deltaTime;
        //update lasors start and end points
        fireBeam.SetPosition(0, laserBeam[0].position);
        fireBeam.SetPosition(1, laserBeam[1].position);

        if (chargeTimer <= 0.21)
        {
            //set color to charge
            fireBeam.colorGradient = colors[0];
            chargeTimer += 0.04f * Time.deltaTime;
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
            this.GetComponent<Collider2D>().enabled = true;
            fireBeam.enabled = true;
        }
        if (damageTimer >= 1) { Destroy(gameObject); }
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        
        if (hitTimer >= 0.6f)
        {
            //check if enemy/get enemy script
            PlayerScript player = hitInfo.GetComponent<PlayerScript>();
            if (player != null)
            {
                //damage enemy
                //player.TakeDamage(Damage);
                Debug.Log("boss lazor hit");
                hitTimer = 0;


            }
        }
    }

}
