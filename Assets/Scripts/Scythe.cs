using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [SerializeField] private float timer;
    private void Update()
    {
        transform.position += Vector3.right * 5f * Time.deltaTime;
    }
}
