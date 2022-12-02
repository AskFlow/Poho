using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(2,10)]
    public float smoothFactor;
    public Vector3 minValues, maxValues;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        //Définir les min values et max values des bounds 


        Vector3 targetPosition = target.position + offset;
        //Verifier si la targetPosition est out of bound
        //Limiter au min et max values
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x,minValues.x, maxValues.x), 
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y), 
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z)
            );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
