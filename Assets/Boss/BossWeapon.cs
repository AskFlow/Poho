using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Transform attackTransform;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Debug.Log("Attack");
        /*
        Collider[] colInfo = Physics.OverlapSphere(attackTransform.position, attackRange);
        foreach (Collider col in colInfo)
        {
            Debug.Log(col.name);
        }*/

    }
    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
