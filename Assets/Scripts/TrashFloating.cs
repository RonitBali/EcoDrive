using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFloating : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // The height of the floating motion
    public float floatSpeed = 1f;      // The speed of the floating motion
    public float rotationSpeed = 50f; // Speed of rotation (optional)

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the trash
        startPosition = transform.position;
    }

    void Update()
    {
        // Create a floating effect using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Optional: Add rotation
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
