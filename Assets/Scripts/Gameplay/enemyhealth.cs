using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    //set death sprite
    public GameObject deathEffect;
    //set health
    public float health = 10;
    //loot table var
    public powerupHandeler thisPowerup;
    public int value;//score value of enemy

    void Start()
    {
        thisPowerup = GetComponent<powerupHandeler>();
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

    //handel for bullet script
    public void TakeDamage(float damage)
    {
        health -= damage;
        //check health
        if (health <= 0)
        {
            Die();
        }
    }
    //should not trigger if not killed by player.
    void Die()
    {
        //allow skip if no death animation set
        if (deathEffect != null)
        {
            //spawn death animation prefab
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        if (GetComponentInChildren<turretScript>() != null)
        {
            GetComponentInChildren<turretScript>().die();
            Debug.Log(this.transform + "sent info to" + GetComponentInChildren<Transform>());
        }
        ObserverScript.Instance.levelScore += value;
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
}
