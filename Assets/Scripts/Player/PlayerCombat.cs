using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackMeleePoint;
    public Transform attackDistancePoint;
    public Camera mainCamera;

    public LayerMask enemyLayers;
    public LayerMask movableLayer;

    public GameObject playerProjectile;

    [SerializeField] private InputActionAsset inputActions;

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
        inputActions.Enable();
    }

    private void Update()
    {
        if(Time.time >= nextAttackMeleeTime){
            if (inputActions.FindAction("AttackMelee").IsPressed()){
                AttackMelee();
                nextAttackMeleeTime = Time.time + 1f / attackMeleeRate;
            }   
        }

        if(Time.time >= nextAttackDistanceTime){
            if (inputActions.FindAction("AttackDistance").IsPressed())
            {
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

    private void OnDrawGizmosSelected() {
        if(attackMeleePoint == null){
            return;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackDistancePoint.position, attackMeleeRange);
    }
}
