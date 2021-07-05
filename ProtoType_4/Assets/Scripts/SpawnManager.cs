using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float timer;
    private PlayerController player;
    private float ran_Spawn_x;
    private float ran_Spawn_z;
    private float spawn_Range = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer < 0 && !player.gameOver)
        {
            
            Instantiate(enemy, RandomEnemy_Pos(), enemy.transform.rotation);
            timer = 10.0f;
        }
        else if (player.gameOver)
        {
            timer = 9999f;
        }
    }
    private Vector3 RandomEnemy_Pos()
    {
        ran_Spawn_x = Random.Range(-spawn_Range, spawn_Range);
        ran_Spawn_z = Random.Range(-spawn_Range, spawn_Range);
        enemy.transform.position = new Vector3(ran_Spawn_x, 0.1f, ran_Spawn_z);
        if ((ran_Spawn_x<3 && ran_Spawn_x>-3) || (ran_Spawn_z<3 && ran_Spawn_z>-3))
        {
            RandomEnemy_Pos();
        }
        return enemy.transform.position;
    }
}
