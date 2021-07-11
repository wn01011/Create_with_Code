using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tartgets : MonoBehaviour
{
    public GameObject[] target;
    private int ranNum;
    private Vector3 ranPos;
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //void SpawnManager()
    //{
    //        Instantiate(target[TargetNumGenerator()], RanPosGenerator(), RanRotGenerator());
    //}
    IEnumerator SpawnTarget()
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, target.Length);
            Instantiate(target[index], RanPosGenerator(), RanRotGenerator());
        }
    }
    

    Vector3 RanPosGenerator()
    {
        ranPos.x = Random.Range(-4.0f, 4.0f);
        ranPos = new Vector3(ranPos.x, 0, 0);
        return ranPos;
    }

    Quaternion RanRotGenerator()
    {
        float x = Random.Range(-90.0f, 90.0f);
        float y = Random.Range(-90.0f, 90.0f);
        float z = Random.Range(-90.0f, 90.0f);
        transform.rotation = Quaternion.Euler(x, y, z);

        return transform.rotation;
    }
}
