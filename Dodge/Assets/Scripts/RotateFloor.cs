using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloor : MonoBehaviour
{
    [UnityEngine.Range(0f,100f)]
    [SerializeField] private float rotationSpeed = 60.0f;
    void Update()
    {
        //transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
