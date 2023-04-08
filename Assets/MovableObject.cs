using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    GameObject player;

    bool isGrab = false;

    private void Start()
    {
        player = GameObject.Find("Player");
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

    void OnMouseDown()
    {
        Vector3 mousePosition = Input.mousePosition;
        BoxCollider col = GetComponent<Collider>() as BoxCollider;

        Debug.Log("YES");
        isGrab = !isGrab;

            foreach (BoxCollider c in GetComponents<BoxCollider>())
            {
                c.isTrigger = isGrab; //Or false if you want to desactivate them all
            }
    }
}