using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag(other.tag)) //If have same tag, ignore. If not, Destroy it
            {}
        else 
            { Destroy(other.gameObject); }
    }
}
