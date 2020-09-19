using UnityEngine;

public class clouds : MonoBehaviour
{
    SpriteRenderer SR;
    Rigidbody2D RB;
    public float Speed;
    public bool swapboolx;
    public bool swapbooly;
    private void Start()
    {
        //get components
        SR = GetComponent<SpriteRenderer>();
        RB = GetComponent<Rigidbody2D>();
        //random blue/green color
        SR.color = new Color(Random.Range(0.0f, 0.5f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
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
        Speed = Random.Range(-8, -20);
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
            SR.color = new Color(Random.Range(0.0f, 0.5f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
            //set var for x,y scale
            float F = Random.Range(0.6f, 1.6f);
            //set scale
            transform.localScale = new Vector3(F,F,1);
            //set random speed
            setspeed();
        }
        //wobble
        float x = transform.localScale.x;
        float y = transform.localScale.y;

        //something to keep scale in range
        if (x > 2) { swapboolx = false; }
        else if (x<1) { swapboolx = true; }
        //range check Y
        if (y > 2) { swapbooly = false; }
        else if (y < 1) { swapbooly = true; }

        //scale change X
        if (swapboolx==true)
        {
            //modify scale
            x+= Random.Range(0.01f, 0.02f);

        }
        else if (swapboolx == false)
        {
            //modify scale
            x -= Random.Range(0.01f, 0.02f);
        }
        //scale change Y
        if (swapbooly == true)
        {
            //modify scale
            y += Random.Range(0.01f, 0.02f);

        }
        else if (swapbooly == false)
        {
            //modify scale
            y -= Random.Range(0.01f, 0.02f);
        }
        //set scale
        transform.localScale = new Vector3(x, y, 1);
    }
    
}
