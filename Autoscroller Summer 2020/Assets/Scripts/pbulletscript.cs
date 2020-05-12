using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pbulletscript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void Update() 
    {
        //incroment timer
        timer += 1.0F * Time.deltaTime;
        //check timer
        if (timer >= 2)
        {
            //destroy game object
            GameObject.Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check if enemy/get enemy script
        enemyscript enemy = hitInfo.GetComponent<enemyscript>();
        if (enemy != null)
        {
            //damage enemy
            enemy.TakeDamage(15);
            //remove bullet
            Destroy(gameObject);
        }
    }
}
