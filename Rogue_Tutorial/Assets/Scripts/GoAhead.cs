using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAhead : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(-90, 0, 0);
    }
    void Update()
    {
        transform.Translate(-transform.forward * speed);
        if(Mathf.Abs(transform.position.x)>=100 || Mathf.Abs(transform.position.z) >= 100)
        {
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Enemy"))
    //    {
    //        Destroy(other);
    //    }
    //}

    private float speed = 1.0f;
}
