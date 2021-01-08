using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    //set death sprite
    public GameObject deathEffect;
    //set health
    public float health;
    public bool isSBoss;
    public bool isBoss;
    public int diff;
    //loot table var
    public powerupHandeler thisPowerup;
    public int value;//score value of enemy
    private bool boop=false;

    void Start()
    {
        diff = ObserverScript.Instance.diff;
        float H=-5;
        switch (diff) 
        {
            case 0://NG+
                H = health * 2f;
                break;
            case 1://easy
                H = health * 0.8f;
                break;
            case 3://hard
                H = health * 1.5f;
                break;
        }
        if (H == -5) {/*do nothing*/}
        else { health = H; }
        thisPowerup = GetComponent<powerupHandeler>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {//rammed by player

        //check if player/get player script
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if (player != null)
        {
            int S=0;
            //damage player
            switch (diff)
            {
                case 0://NG+
                    //set damage
                    player.TakeDamage(health * 4);
                    //score reduction for ramming
                    S = 0;
                    break;
                case 1://easy
                    player.TakeDamage(health * 1.5f);
                    //score reduction for ramming
                    S = value;
                    break;
                case 2://normal
                    player.TakeDamage(health * 2f);
                    //score reduction for ramming
                    S = value / 2;
                    break;
                case 3://hard
                    player.TakeDamage(health * 2.5f);
                    //score reduction for ramming
                    S = value / 4;
                    break;
            }
            value = S;
            //die
            Die();
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
            if (boop == false) 
            {
                //multitrigger prevention
                boop = true;
                //allow skip if no death animation set
                if (deathEffect != null)
                {
                    //spawn death animation prefab
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                }
                if (GetComponentInChildren<turretScript>() != null)
                {
                    makeLoot();
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
