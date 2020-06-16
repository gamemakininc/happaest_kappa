using UnityEngine;

public class TileScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
        transform.parent = null;
        Destroy(parent);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-2.5f, 0);
    }
}
