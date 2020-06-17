using UnityEngine;

public class thrusterFire : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check for scripts
        enemyscript enemy =hitInfo.GetComponent<enemyscript>();
        ebulletscript ebullet = hitInfo.GetComponent<ebulletscript>();
        pbulletscript pbullet = hitInfo.GetComponent<pbulletscript>();
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        //check what script was pulled
        if (ebullet != null)
        {
            //remove ebullet
            ebullet.die();
        }
        if (pbullet != null)
        {
            //remove pbullet
            pbullet.die();
        }
        if (player != null)
        {
            //damage player
            player.TakeDamage(damage);
        }
        if (enemy != null) {enemy.TakeDamage(damage); }
    }

}
