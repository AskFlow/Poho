using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float followDistance;
    public float smoothTime;
    public float rotationSpeed;


    private  PlayerMovement playerMovement;
    private Vector3 interm;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset;
    private Quaternion targetRotation;

    void Start()
    {
        offset = transform.position - player.transform.position;
        playerMovement = player.GetComponent<PlayerMovement>();

    }

    void FixedUpdate()
    {

        interm = new Vector3(offset.x* playerMovement.direction + -1.13661f, offset.y + 3.46f, offset.z + 0.4494041f);
        Vector3 targetPosition = player.transform.position + interm;

        targetPosition.x += followDistance;


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0f;

        if (direction.magnitude > 0.1f)
        {
            targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Calculer l'angle de rotation en fonction de la direction du joueur
            float angle = playerMovement.direction > 0 ? 60f : 120f;
            Quaternion angleRotation = Quaternion.Euler(0f, angle, 0f);

            // Faire pivoter la rotation actuelle du robot vers la rotation cible
            targetRotation = Quaternion.RotateTowards(transform.rotation, angleRotation, rotationSpeed * Time.deltaTime);
        }

        transform.rotation = targetRotation;
    }
}