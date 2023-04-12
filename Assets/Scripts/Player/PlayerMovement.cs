using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 5;
    public float JumpSpeed = 15;

    public float direction = 1.0f;

    public bool isJumping;
    public bool isGrounded;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode backwardKey = KeyCode.G;
    public KeyCode attackKey = KeyCode.B;
    public KeyCode forwardKey = KeyCode.C;
    public KeyCode useKey = KeyCode.E;





    float distToGround;
    public Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {


        float h = Input.GetAxis("Horizontal") * Speed;
        if(h > 0.0f)
        {
            direction = 1.0f;
        }
        else if (h < 0.0f)
        {
            direction = -1.0f;
        }

        rb.velocity = new Vector2(h, rb.velocity.y);

        if (Input.GetKeyDown(jumpKey) && CheckGround()){
            isJumping = true;
        }

        if(isJumping == true){
            rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
            isJumping = false;
        }
    }

    public bool CheckGround()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
