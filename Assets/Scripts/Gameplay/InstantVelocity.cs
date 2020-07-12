using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour
{
    public Vector2 velocity = new Vector2(-1.0f, 0.0f);
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
    }
}
