using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    // Range et dégâts de l'attaque
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    // Attaques par secondes
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime){
            if (Input.GetKeyDown(KeyCode.E)){
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }   
        }
    }

    void Attack(){
        // Jouer l'animation de l'attaque (à l'avenir)

        // Detecter les ennemies dans la range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Appliquer les damages
        foreach(Collider enemy in hitEnemies){
            Debug.Log("Vous avez touché " + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint == null){
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
