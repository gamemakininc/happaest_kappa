using UnityEngine;

public class TileScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject parent;

    public float speed = -2.5f;
    [Tooltip("Freezes the tile on Screen")]
    public bool freeze;
    private bool frozen;

    private float cameraBoundX;
    private float tileEdgeX;

    void Start()
    {
        parent = transform.parent.gameObject;
        transform.parent = null;
        Destroy(parent);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);

        cameraBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;
        tileEdgeX = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void Update()
    {
        if (frozen == false) 
        {
            if (freeze == true) { speed = 0; frozen = true; }
        }
        float xDif = tileEdgeX - cameraBoundX;

        if (freeze && xDif < float.Epsilon || freeze && xDif < 0) //Freezes tile on Screen
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }
}
