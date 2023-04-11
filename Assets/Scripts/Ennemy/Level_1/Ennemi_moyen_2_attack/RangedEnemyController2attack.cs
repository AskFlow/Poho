using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController2attack : MonoBehaviour
{
    public GameObject bullet;
    public LayerMask PlayerLayer;
    public Transform bulletpos;
    public bool canShoot;
    public float timer;
    //////////////////
    public float moveSpeed;
    public Transform player;
    public Transform shotPoint;
    public Transform gun;
    public Vector3 startpoint;


    public float followPlayerRange;
    private bool inRange;
    public float attackRange;

    public float startTimeBtwnShots;
    private float timeBtwnShots;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

   

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

        if (Vector3.Distance(transform.position, player.position) <= followPlayerRange && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            inRange = true;
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
              
            }
        }
        else if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            inRange = true;
           
            if (Time.time >= nextAttackTime)
            {
                AttackMelee();
                nextAttackTime = Time.time + 3f / attackRate;
                Debug.Log("attackmelee");
            }
            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, startpoint, moveSpeed * Time.deltaTime);
            inRange = false;

            Vector3 playerPos = player.position;
            playerPos.y = transform.position.y;
            Quaternion targetRotation = Quaternion.LookRotation(playerPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500f * Time.deltaTime);
        }      
    }

    void FixedUpdate()
    {
        if (inRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, followPlayerRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
     public void shoot()
    {
      
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
        
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, followPlayerRange, PlayerLayer);

        // Appliquer les damages
        foreach (Collider Player in hitPlayer)
        {
            Debug.Log("Vous avez touché " + Player.name);
        }
    }


    void AttackMelee()
    {
        // Jouer l'animation de l'attaque (à l'avenir)
        
        // Detecter les ennemies dans la range
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, attackRange, PlayerLayer);
       
        // Appliquer les damages
        foreach (Collider Player in hitPlayer)
        {
            Debug.Log("Vous avez touché " + Player.name);           
        }
    }
}
