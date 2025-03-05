using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The car to follow
    public Vector3 offset;   // Offset position relative to the target
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            Debug.Log("Target Position: " + target.position);
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
        else
        {
            Debug.LogError("Target not assigned in CameraFollow script!");
        }
    }

}
