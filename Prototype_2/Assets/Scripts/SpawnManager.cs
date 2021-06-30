using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float xRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomNum = Random.Range(0, animalPrefabs.Length);
        float xRandomSpawn = Random.Range(-xRange, xRange);
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(animalPrefabs[randomNum], new Vector3(xRandomSpawn, transform.position.y, transform.position.z), animalPrefabs[randomNum].transform.rotation);
        }
    }
}
