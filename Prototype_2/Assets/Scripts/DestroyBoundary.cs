using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.z > 30.0f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
            Debug.Log("Balls have did it!!");
        }
        
    }
}
