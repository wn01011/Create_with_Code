using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnManager = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
            MoveToward();
    }
    private void MoveToward()
    {
        Vector3 dir = Player.transform.position;
        transform.LookAt(dir);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Player.GetComponent<PlayerController>().isDead = true;
            Debug.Log("you Die!");
        }
        else if (other.CompareTag("Bullet")) 
        {
            Destroy(gameObject);
            int killc = ++SpawnManager.GetComponent<SpawnEnemy>().killcount;
            Debug.Log("Kill Count : " + killc);
        }
    }
    private GameObject Player;
    private float speed = 5.0f;
    public GameObject SpawnManager;
}
