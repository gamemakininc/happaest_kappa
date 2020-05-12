using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementScale = 1;

    void Start()
    {
        CharacterController character = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float velocityX = Input.GetAxis("Horizontal") * movementScale;
        float velocityY = Input.GetAxis("Vertical") * movementScale;


    }
}
