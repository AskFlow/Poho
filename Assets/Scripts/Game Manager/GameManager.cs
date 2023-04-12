using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private AudioSystem audioSystem;
    

    public int maxHealth;
    public int currenthealth;

    void Start()
    {

        currenthealth = maxHealth;

        audioSystem = gameObject.GetComponent<AudioSystem>();
           
    }

    void Update()
    {
        
    }

    public void playAudio()
    {
        audioSystem.ReturnAudio();
    }



    void TakeDamage(int damage)
    {
        currenthealth -= damage;

        if (currenthealth < 0)
        {
            Destroy(gameObject);

        }
    }
}
