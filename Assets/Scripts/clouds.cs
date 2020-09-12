using UnityEngine;

public class clouds : MonoBehaviour
{
    SpriteRenderer SR;
    Rigidbody2D RB;
    public float Speed;
    private void Start()
    {
        //get components
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
        //random blue/green color
        SR.color = new Color(0f, Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
        //set var for x,y scale
        float F = Random.Range(0.6f, 1.6f);
        //set scale
        transform.localScale = new Vector3(F, F, 1);
        //set random speed
        setspeed();

    }
    void setspeed()
    {
        //set random speed
        Speed = Random.Range(-9, -15);
        //apply speed
        RB.velocity = transform.right * Speed;
    }
    // Update is called once per frame
    void Update()
    {
        //if offscrean
        if (transform.position.x < -9.5) 
        {
            //reset postiton
            transform.position = new Vector3(10,Random.Range(4.8f,-4.8f), 0);
            //random blue/green color
            SR.color = new Color (0f, Random.Range(0.5f,1f), Random.Range(0.5f, 1f));
            //set var for x,y scale
            float F = Random.Range(0.6f, 1.6f);
            //set scale
            transform.localScale = new Vector3(F,F,1);
            //set random speed
            setspeed();
        }
    }
}
