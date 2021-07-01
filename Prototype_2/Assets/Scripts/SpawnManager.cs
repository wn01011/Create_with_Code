using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xRange = 14.0f;
    public float zRange = 25.0f;

    private float startDelay = 2.0f;
    private float spawnDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnDelay);
            
        }
    }
    void SpawnRandomAnimal()
    {
        int randomNum = Random.Range(0, animalPrefabs.Length);
        float xRandomSpawn = Random.Range(-xRange, xRange);


        Instantiate(animalPrefabs[randomNum], new Vector3(xRandomSpawn, 0, zRange), animalPrefabs[randomNum].transform.rotation);

    }
}
