using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Animator animator;
    public float moveSpeed;
    public Transform player;
    public Vector3 startpoint;

    //public Transform gun;
    //public Transform shotPoint;
    //public GameObject enemyProjectile;

    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimeAttack;
    private float timeAttack;

    private bool isAttacking = false;
    private bool isMoving = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {       
        startpoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {        
        /*
        Vector3 differance = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        */

        if (Vector3.Distance(transform.position, player.position) <= followPlayerRange && Vector3.Distance(transform.position, player.position) >= attackRange && !isAttacking)
        {
            inRange = true;
            isMoving = true;
            animator.SetFloat("moveSpeed", moveSpeed);

            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
        else if ((!(transform.position.x >= startpoint.x - 1 && transform.position.x <= startpoint.x + 1) || !(transform.position.z >= startpoint.z - 0.2 && transform.position.z <= startpoint.z + 0.2)) && !isAttacking && isMoving)
        {
            //Debug.Log("NOT");
            transform.position = Vector3.MoveTowards(transform.position, startpoint, moveSpeed * Time.deltaTime);
            inRange = false;
            animator.SetFloat("moveSpeed", moveSpeed);

            Vector3 spawnPos = startpoint;
            spawnPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(spawnPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        } 
        else
        {
            animator.SetFloat("moveSpeed", 0f);
            isMoving = false;
        }

        if (((transform.position.x >= startpoint.x - 1 && transform.position.x <= startpoint.x + 1) && (transform.position.z >= startpoint.z - 0.2 && transform.position.z <= startpoint.z + 0.2)) || isAttacking)
        {
            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
 
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (timeAttack <= 0 && !isAttacking)
            {
                Debug.Log("Attack");
                isAttacking = true;
                if (GetComponent<EnemyHealth>().getCurrentHealth() <= GetComponent<EnemyHealth>().getMaxHealth() * 0.5)
                {
                    animator.SetTrigger("attackJump");
                } else
                {
                    animator.SetTrigger("attackSimple");
                }
                
                timeAttack = startTimeAttack;
            }
            else
            {
                timeAttack -= Time.deltaTime;
            }
        }
    }
 
    void FixedUpdate()
    {
        if (inRange)
        {
            Vector3 playerPos = player.position;
            //playerPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
    }
 
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Attack()
    {
        //Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
        isAttacking = false;
    }
}
