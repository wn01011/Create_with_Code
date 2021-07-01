using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject my_dog;
    private float dogSpawnInterval = 0.5f;
    private float timePressed;
    void Start()
    {
        timePressed = dogSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timePressed -= Time.deltaTime;
        if (timePressed < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(my_dog, new Vector3(0, 0, 4), my_dog.transform.rotation);
                timePressed = dogSpawnInterval;
            }
        }
    }
}
