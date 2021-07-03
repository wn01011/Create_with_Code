using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
   
    private float repeatRate = 2.0f;
    public PlayerController playerController;
   

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        //InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        repeatRate -= Time.deltaTime;
        if (repeatRate < 0)
        {
            SpawnObstacle();
            repeatRate = 2.0f;
        }
        
        
        if (playerController.gameOver == true)
        {
            repeatRate = 999f;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(30, 0, 0), obstacle.transform.rotation);
    }
}
