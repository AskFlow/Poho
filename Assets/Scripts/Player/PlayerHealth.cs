using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public List<CheckPoints> checkpoints;
    public GameObject playerPrefab;
    private GameObject player;
    private CheckPoints lastCheckpoint;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = new List<CheckPoints>();
        player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        lastCheckpoint = checkpoints[0];
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        Debug.Log("Player mort !");

        transform.position = lastCheckpoint.position;
        currentHealth = maxHealth;
        // Animation de mort � l'avenir
    }

    public void ActivateCheckpoint(CheckPoints checkpoint)
    {
        // Activer le checkpoint
        checkpoint.activated = true;

        // Mettre � jour le dernier checkpoint atteint
        Debug.Log("MAJ du checkpoint");
        lastCheckpoint = checkpoint;
    }
     void Update()
    {

    }
}
