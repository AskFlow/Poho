using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 5;
    public float JumpSpeed = 5;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        isGrounded = Physics2D.OverlapArea(groundCheck.position, groundCheck.position);


        float h = Input.GetAxis("Horizontal") * Speed;

        rb.velocity = new Vector2(h, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isJumping = true;
        }

        if(isJumping == true){
            rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
            isJumping = false;
        }
    }
}
