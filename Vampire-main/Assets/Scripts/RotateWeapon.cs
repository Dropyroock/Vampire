using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // You can set the rotation axis in the Inspector

    private void Update()
    {
        // Rotate the object around the specified axis at a constant speed
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    
}
