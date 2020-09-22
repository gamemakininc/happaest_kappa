using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    //set death sprite
    public GameObject deathEffect;
    //set health
    public float health;
    public bool isSBoss;
    public bool isBoss;

    //loot table var
    public powerupHandeler thisPowerup;
    public int value;//score value of enemy

    void Start()
    {
        float H=-5;
        switch (ObserverScript.Instance.diff) 
        {
            case 0://NG+
                H = health * 1.6f;
                break;
            case 1://easy
                H = health * 0.8f;
                break;
            case 3://hard
                H = health * 1.2f;
                break;
        }
        if (H == -5) {/*do nothing*/}
        else { health = H; }
        thisPowerup = GetComponent<powerupHandeler>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if player/get player script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            ObserverScript.Instance.levelScore += value / 2;
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
        if (isBoss == false)
        {
            //allow skip if no death animation set
            if (deathEffect != null)
            {
                //spawn death animation prefab
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            ObserverScript.Instance.levelScore += value;
            makeLoot();
            //remove self
            Destroy(gameObject);
        }
        else 
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
                Debug.Log(transform + "sent info to" + GetComponentInChildren<Transform>());
            }
            ObserverScript.Instance.levelScore += value;
            //dont want to delete the tile static boss is on
            if (isSBoss == false)
            {
                ObserverScript.Instance.type2++;
                //get wave spawner script refrence
                EnemyWavev2 waveSpner = FindObjectOfType<EnemyWavev2>();
                //end level win state
                waveSpner.OnLevelComplete();
            }
            //remove self
            Destroy(gameObject);

        }
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
