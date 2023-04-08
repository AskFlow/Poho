using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackMeleePoint;
    public Transform attackDistancePoint;
    public LayerMask enemyLayers;

    public GameObject playerProjectile;

    // Range et dégâts de l'attaque Melee
    public float attackMeleeRange = 1.5f;
    public int attackMeleeDamage = 40;

    // Dégâts de l'attaque à distance
    public int attackDistanceDamage = 20;

    // Attaques par secondes
    public float attackMeleeRate = 2f;

    public float attackDistanceRate = 2f;

    float nextAttackMeleeTime = 0f;

    float nextAttackDistanceTime = 0f;

    void Update()
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

    void AttackMelee(){
        // Jouer l'animation de l'attaque (à l'avenir)

        // Detecter les ennemies dans la range
        Collider[] hitEnemies = Physics.OverlapSphere(attackMeleePoint.position, attackMeleeRange, enemyLayers);

        // Appliquer les damages
        foreach(Collider enemy in hitEnemies){
            Debug.Log("Vous avez touché " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackMeleeDamage);
        }
    }

    void AttackDistance(){
        // Jouer l'animation de l'attaque (à l'avenir)

        Instantiate(playerProjectile, attackDistancePoint.position, attackDistancePoint.rotation);
    }

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
