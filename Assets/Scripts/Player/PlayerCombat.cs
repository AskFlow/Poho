using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackMeleePoint;
    public Transform attackDistancePoint;
    public Camera mainCamera;

    public LayerMask enemyLayers;
    public LayerMask movableLayer;

    public GameObject playerProjectile;

    private Animator animator;

    // Range et dégâts de l'attaque Melee
    public float attackMeleeRange = 1.5f;
    public int attackMeleeDamage = 40;

    // Dégâts de l'attaque à distance
    public int attackDistanceDamage = 20;

    // Attaques par secondes
    public float attackMeleeRate = 2f;
    public float attackDistanceRate = 2f;
    public float moveObjectDistance = 3f;
                                
    float nextAttackMeleeTime = 0f;

    float nextAttackDistanceTime = 0f;
    EnemyHealth enemyHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.time >= nextAttackMeleeTime){
            if (Input.GetKeyDown(KeyCode.E)){
                AttackMelee();
                nextAttackMeleeTime = Time.time + 1f / attackMeleeRate;
            }   
        }

        if(Time.time >= nextAttackDistanceTime){
            if (Input.GetKeyDown(KeyCode.F)){
                AttackDistance();
                nextAttackDistanceTime = Time.time + 1f / attackDistanceRate;
            }   
        }
    }

    void AttackMelee()
    {
        // Jouer l'animation de l'attaque
        animator.SetTrigger("isAttackingMelee");

        // Detecter les ennemies dans la range
        Collider[] hitEnemies = Physics.OverlapSphere(attackMeleePoint.position, attackMeleeRange, enemyLayers);

        // Appliquer les damages
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Vous avez touché " + enemy.name);
            enemy.GetComponent<EnemyHealth>().ApplyDamage(attackMeleeDamage);
        }
    }

    void AttackDistance(){
        // Jouer l'animation de l'attaque (à l'avenir)

        Instantiate(playerProjectile, attackDistancePoint.position, attackDistancePoint.rotation);
    }

    //void MoveObject()
    //{
    //    Debug.Log("MoveObject");

    //    //RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, screenPosition - transform.position, moveObjectDistance);

    //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out RaycastHit hitObstacle, float.MaxValue, movableLayer))
    //    {
    //        if (hitObstacle.collider != null)
    //        {
    //            GameObject objectToMovable = hitObstacle.collider.gameObject;

    //            objectToMovable.transform.SetPositionAndRotation(Input.mousePosition, objectToMovable.transform.rotation);
    //        }
    //    }

    //    /*if (hitObstacle.collider != null)
    //    {
    //        Debug.Log(hitObstacle.collider.name);
    //        Debug.DrawRay(transform.position, screenPosition - transform.position, Color.red);
    //    }
    //    else
    //    {
    //        Debug.DrawRay(transform.position, screenPosition - transform.position, Color.green);
    //    }*/
    //}

    //Raycast check if WallMovable
    //public string objectCast()
    //{
    //    Debug.Log("objectCast");
    //    string result = "";
    //    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRayObject.transform.position, mouseWorldPosition - obstacleRayObject.transform.position, obstacleRayDistance);
    //    if (hitObstacle.collider != null)
    //    {
    //        Debug.Log(hitObstacle.collider.name);
    //        result = hitObstacle.collider.name;
    //        Debug.DrawRay(obstacleRayObject.transform.position, mouseWorldPosition - obstacleRayObject.transform.position, Color.red);
    //    }
    //    else
    //    {
    //        Debug.DrawRay(obstacleRayObject.transform.position, mouseWorldPosition - obstacleRayObject.transform.position, Color.green);
    //    }
    //    return result;
    //}

    private void OnDrawGizmosSelected() {
        if(attackMeleePoint == null){
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackDistancePoint.position, attackMeleeRange);
    }
}
