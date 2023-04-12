using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    GameObject player;
    BoxCollider col;
    public LayerMask movableLayer;

    bool isGrab = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        col = GetComponent<Collider>() as BoxCollider;
    }

    private void Update()
    {
        if (isGrab)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));

            if (Physics.Raycast(player.transform.position, transform.position - player.transform.position, 7.0f, movableLayer))
            {
                transform.position = newPos;
            } else
            {
                isGrab = false;
            }
        }
    }

    void OnMouseOver()
    {
        Debug.DrawRay(player.transform.position, transform.position - player.transform.position, Color.red);

        if (Input.GetKey(KeyCode.R))
        {
            if (Physics.Raycast(player.transform.position, transform.position - player.transform.position, 7.0f, movableLayer))
            {
                isGrab = true;
                col.isTrigger = true;
            }
        }
        else
        {
            isGrab = false;
            col.isTrigger = false;
        }
    }
}