using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class enemyscript : MonoBehaviour
{
    /// If you're adding any variables that you want to see in the inspector, go to Assets/Editor/enemyscriptEditor.cs
    //set health
    public int health = 100;
    //set death sprite
    public GameObject deathEffect;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentState = (states)currentTab;
    }

    //movement pattern
    public enum states
    {
        straight, 
        wavy, 
        slide
    }

    public states currentState;
    public float speed = 1;

    [HideInInspector]
    public int currentTab;
    public string currentField;

    [Header("Wavy Attributes")]
    public float amplitude = 1;
    public float period = 0.3f;
    public float shift;
    public float yChange = 0.1f;
    private float newX;
    private float newY;

    [Header("Slide Attributes")]
    public float waitTime = 3.0f;
    public float slideTime = 2.0f;
    public bool moveRight;


    //handel for bullet script
    public void TakeDamage(int damage) 
    {
        health -= damage;
        //check health
        if (health <= 0)
        {
            Die();
        }
    }
    void Die() 
    {
        //spawn death sprite
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //remove self
        Destroy(gameObject);
    }

    

    void FixedUpdate()
    {
        //Check method of movement
        #region CurrentState
        switch (currentState)
        {
            case states.straight:
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                break;
            case states.wavy:
                newY = transform.position.y - yChange;
                newX = amplitude * Mathf.Sin(period * newY) + shift;
                Vector2 tempPosition = new Vector2(newX, transform.position.y);
                transform.position = tempPosition;
                rb.velocity = new Vector2(rb.velocity.x, -speed);
                break;
            case states.slide:
                if(waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    rb.velocity = new Vector2(0, -speed);
                }
                else
                {
                    if(slideTime > 0)
                    {
                        waitTime -= Time.deltaTime;
                        if(moveRight)
                            rb.velocity = new Vector2(speed * 1.5f, -speed);
                        else
                            rb.velocity = new Vector2(-speed * 1.5f, -speed);
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, -speed);
                    }
                }
                break;
            default:
                break;
        }
        #endregion
    }
}


