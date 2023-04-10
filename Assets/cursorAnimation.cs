using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorAnimation : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        gameObject.transform.position = mousePos;

    }
}
