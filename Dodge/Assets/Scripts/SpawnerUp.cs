using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUp : MonoBehaviour
{
    private float timer = 10.0f;
    public BulletSpawner[] spawner;
    private int cycle = 1;

    void Update()
    {
        CreateSpawner();
    }
    void CreateSpawner()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            if (cycle >= 4) return;
            spawner[cycle].gameObject.SetActive(true);
            timer = 10;
            cycle++;
        }

    }
}
