using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossCamera : MonoBehaviour
{

    public Transform BackGroundTarget;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        Centered();
    }

    void Centered()
    {
        Vector3 targetPosition = BackGroundTarget.position ;
        Quaternion targetRotation = BackGroundTarget.rotation ;
        targetPosition.z = -16;
        targetPosition.y = 5.34f;
        targetRotation.x = -4.54f;

        transform.position = targetPosition;
    }

}
