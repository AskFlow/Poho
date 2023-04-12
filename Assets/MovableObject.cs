using System.Collections;
using System.Collections.Generic;
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
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }

    void OnMouseOver()
    {
        Debug.DrawRay(player.transform.position, transform.position, Color.red);

        if (Input.GetKey(KeyCode.R))
        {
            RaycastHit hit;

            if (Physics.Raycast(player.transform.position, transform.position, out hit, 10.0f, movableLayer))
            {
                Debug.Log("oui");

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