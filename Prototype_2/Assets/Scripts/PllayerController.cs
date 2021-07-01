using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PllayerController : MonoBehaviour
{
    private float speed = 20.0f;
    public GameObject projectile;
    public float xRange = 14.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiMove = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * horiMove * Time.deltaTime * speed); // horizontal move

        //if press 'Space' key, shoot specific Food;

        bool shoot = Input.GetKeyDown(KeyCode.Space);

        if (shoot)
        {
            Instantiate(projectile, new Vector3(transform.position.x, 2.0f, transform.position.z), projectile.transform.rotation);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }



    }
}
