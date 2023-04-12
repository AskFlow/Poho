using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        // Animation de dégâts à l'avenir

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player mort !");

        Destroy(gameObject);

        // Animation de mort à l'avenir
    }
}
