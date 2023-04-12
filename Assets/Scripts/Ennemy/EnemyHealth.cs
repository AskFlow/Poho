using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    [SerializeField]
    private float currentHealth;
    public Animator animator;

    private void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage){
        currentHealth -= damage;
        // Animation de dégâts à l'avenir

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        animator.SetTrigger("die");
        Debug.Log("Ennemi mort !");
    }

    void DestroyEnnemy()
    {
        Destroy(gameObject);
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
    public float getMaxHealth()
    {
        return maxHealth;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Shockwave")
        {
            if (!(currentHealth <= 0))
            {
                ApplyDamage(20);
            }    
        }
    }
}
