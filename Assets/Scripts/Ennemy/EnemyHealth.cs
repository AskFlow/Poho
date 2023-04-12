using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]
    private int currentHealth;

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
        Debug.Log("Ennemi mort !");

        Destroy(gameObject);

        // Animation de mort à l'avenir
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Shockwave")
        {
            ApplyDamage(20);
        }
    }
}
