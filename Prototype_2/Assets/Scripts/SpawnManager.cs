using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] ball;
    private float spawnTime;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InvokeRandom();
        }
    }

    void InvokeRandom()
    {
        UpdateSpawnTime();
        Invoke(nameof(RandomSpawn), spawnTime);
    }
    void UpdateSpawnTime()
    {
        spawnTime = Random.Range(2, 5);
    }

    void RandomSpawn()
    {
        float randomNum = Random.Range(10, 30);
        int ballIndex = Random.Range(0, 3);

        Instantiate(ball[ballIndex], new Vector3(0, 10, randomNum), ball[ballIndex].transform.rotation);
        InvokeRandom();
    }
}
