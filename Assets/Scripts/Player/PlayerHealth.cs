using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    public void ApplyDamage(int damage)
    {
       currentHealth -= damage;  

        healthBar.SetHealth(currentHealth);

        // Animation de d�g�ts � l'avenir
        if (currentHealth <= 0)
        {           
            Die();
        }
    }

    void Die()
    {
        if (gameManager.lastCheckPointPos == Vector2.zero) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Player retourné au checkpoint !");

        transform.position = gameManager.lastCheckPointPos;
        currentHealth = maxHealth;

        // Animation de mort � l'avenir
    }
}
