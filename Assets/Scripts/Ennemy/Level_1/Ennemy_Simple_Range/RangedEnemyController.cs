using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour
{

    Animator animator;
    public float moveSpeed;
    public Transform player;
    public Transform shotPoint;
    public Transform gun;
    public Vector3 startpoint;

    public GameObject enemyProjectile;
 
    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimeBtwnShots;
    private float timeBtwnShots;

    private bool isAttacking = false;

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
        Vector3 differance = player.position - gun.transform.position;
        float rotZ = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        

        if (Vector3.Distance(transform.position, player.position) <= followPlayerRange && Vector3.Distance(transform.position, player.position) >= attackRange && !isAttacking)
        {
            inRange = true;
            animator.SetFloat("walk", moveSpeed);

            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
        else if ((!(transform.position.x >= startpoint.x - 1 && transform.position.x <= startpoint.x + 1) || !(transform.position.z >= startpoint.z - 0.2 && transform.position.z <= startpoint.z + 0.2)) && !isAttacking)
        {
            Debug.Log("NOT");
            transform.position = Vector3.MoveTowards(transform.position, startpoint, moveSpeed * Time.deltaTime);
            inRange = false;
            animator.SetFloat("walk", moveSpeed);

            Vector3 spawnPos = startpoint;
            spawnPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(spawnPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        } 
        else
        {
            animator.SetFloat("walk", 0f);
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
            if (timeBtwnShots <= 0 && !isAttacking)
            {
                isAttacking = true;
                animator.SetTrigger("attack");
                timeBtwnShots = startTimeBtwnShots;
            }
            else
            {
                timeBtwnShots -= Time.deltaTime;
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
        Instantiate(enemyProjectile, shotPoint.position, shotPoint.transform.rotation);
        isAttacking = false;
    }
}
