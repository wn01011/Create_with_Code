using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private float startDelay = 1.0f;
    private float repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(30, 0, 0), obstacle.transform.rotation);
    }
}
