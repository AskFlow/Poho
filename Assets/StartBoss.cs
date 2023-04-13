using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cameraBoss;
    private bool boss;

    private void Update()
    {
        if (boss) mainCamera.transform.position = cameraBoss.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boss = true;
        }
    }
}
