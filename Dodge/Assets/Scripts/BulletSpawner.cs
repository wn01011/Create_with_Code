using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 3.0f;

    private Transform target;
    private float spwanRate;
    private float timeAfterSpawn;
    private PlayerController playerController;
    void Start()
    {
        timeAfterSpawn = 0.0f;
        playerController = FindObjectOfType<PlayerController>();
        if(playerController != null)
            target = FindObjectOfType<PlayerController>().transform;
        
    }

    void Update()
    {
        
        timeAfterSpawn -= Time.deltaTime;
        if (timeAfterSpawn <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation * myLookAt());
            timeAfterSpawn = RandomSpawnRate();
        }
    }
    private Quaternion myLookAt()
    {
        if (target != null)
        {
            Vector3 targetVec = target.position - transform.position;
            targetVec.Normalize();
            float cosDirVec = Vector3.Dot(transform.forward, targetVec);
            float dirVec = Mathf.Acos(cosDirVec);
            dirVec *= Mathf.Rad2Deg;
            //float dirVec = Vector3.Angle(transform.forward, targetVec);
            Vector3 perp = Vector3.Cross(transform.forward, targetVec);
            Quaternion targetRot = Quaternion.AngleAxis(dirVec, perp);
            return targetRot;
        }
        else
            return transform.rotation;
    }
    private float RandomSpawnRate()
    {
        return Random.Range(spawnRateMin, spawnRateMax);
    }
}
