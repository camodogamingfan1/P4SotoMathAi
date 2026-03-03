using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathAI : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 3f;
    public float rotationSpeed = 200f;
    public float stopDistance = 0.5f;

    void Update()
    {
        if (target == null) return;

        // 1️ Cartesian Coordinates
        Vector2 myPosition = transform.position;
        Vector2 targetPosition = target.position;

        // 2 Vector
        Vector2 direction = targetPosition - myPosition;

        // 3️ Distance
        float distance = direction.magnitude;

        // Normalize direction
        direction.Normalize();

        // 4️ Dot Product (alignment check)
        float dot = Vector2.Dot(transform.up, direction);

        // 5️ Cross Product (left or right?)
        float cross = Vector3.Cross(transform.up, direction).z;

        // Rotate toward player
        transform.Rotate(Vector3.forward, cross * rotationSpeed * Time.deltaTime);

        // Move forward only if not too close
        if (distance > stopDistance)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        // Debug for explanation
        Debug.Log("Distance: " + distance);
        Debug.Log("Dot: " + dot);
        Debug.Log("Cross: " + cross);
    }
}