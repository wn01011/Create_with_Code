using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    void Start()
    {
        for(int i =1; i<=3; i++)
        {
            int mul = 3 * i;
            Invoke("Spawnenemy",mul);
        }
    }
    private void Spawnenemy()
    {
        Instantiate(enemy[0], RandomPos(),enemy[0].transform.rotation);
    }
    private Vector3 RandomPos()
    {
        Vector3 enemyPos;
        enemyPos.x = Random.Range(-30f, 30f);
        enemyPos.z = Random.Range(-30f, 30f);
        enemyPos.y = 1;
        if (Mathf.Abs(enemyPos.x) < 10f || Mathf.Abs(enemyPos.z) < 10f)
            RandomPos();
        return enemyPos;
    }

    public GameObject[] enemy;
    public int killcount = 0;
}
