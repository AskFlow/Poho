using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public float totalAttackTimer = 1.0f;
    private float attackTimer = 0.0f;

    void Update()
    {
        attackTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && attackTimer <= 0)
        {
            attackTimer = totalAttackTimer;
            collision.GetComponent<PlayerHealth>().ApplyDamage(attackDamage);  
        }
    }
}
