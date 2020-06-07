using UnityEngine;

public class powerUps : MonoBehaviour
{
    public SpriteRenderer sr;
    public int powerupID;
    public PlayerScript collector;
    public Animator animator;
    private float timer;
    public Rigidbody2D rb;
    private void Start()
    {
        animator.SetFloat ("Blend", powerupID);
    }
    private void FixedUpdate()
    {
        //incroment timer
        timer += 1.0F * Time.deltaTime;

        if (timer >= 8)
        {
            //destroy game object
            GameObject.Destroy(gameObject);
        }
        if (this.transform.position.y > 0.5) { rb.gravityScale=0.09f; }
        if (this.transform.position.y < -0.5) { rb.gravityScale = -0.09f; }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if player/get player script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            if (powerupID == 1 && player.involActive == false) { player.invincibility(); Destroy(gameObject); }
            if (powerupID == 2 && player.fireBuffActive == false) { player.fireBuff(); Destroy(gameObject); }
            if (powerupID == 3) { player.addMissiles(); Destroy(gameObject); }
        }
    }
}
