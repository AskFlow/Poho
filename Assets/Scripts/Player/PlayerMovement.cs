using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 5;
    public float JumpSpeed = 15;
    public float direction = 1.0f;
    public float zAxis;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;

    private Animator animator;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        zAxis = transform.position.z;
    }

    void Update() {

        float h = Input.GetAxis("Horizontal") * Speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);

        if(transform.rotation.y > 0) { transform.rotation = Quaternion.Euler(0, 90, 0); }
        else if (transform.rotation.y < 0) { transform.rotation = Quaternion.Euler(0, -90, 0); }

        if (h > 0.0f)
        {
            direction = 1.0f;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (h < 0.0f)
        {
            direction = -1.0f;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        rb.velocity = new Vector2(h, rb.velocity.y);

        if(rb.velocity != Vector3.zero){
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CheckGround()){
            isJumping = true;
        }

        if(isJumping == true){
            rb.AddForce(transform.up * JumpSpeed, ForceMode.Impulse);
            isJumping = false;
        }
    }

    public bool CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.1f))
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {       
        //if (other.CompareTag("Checkpoint"))
        //{
        //    Debug.Log("oui");
        //    CheckPoints checkpoint = other.GetComponent<CheckPoints>();
        //    if (!checkpoint.activated)
        //    {
        //        playerHealth.ActivateCheckpoint(checkpoint);
        //    }
        //}
    }
}
