using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;

    public float topBound = 30.0f;
    public float lowBound = -5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if ( transform.position.z >= topBound || transform.position.z < lowBound )  // z축으로 경계면 지정후 넘으면 파괴
        {
            Destroy(gameObject);
        }
    }
}
