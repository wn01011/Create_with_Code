using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemy_Rb;
    private float speed = 3.0f;
    private Vector3 lookDirecton;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy_Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirecton = player.transform.position - transform.position;
        enemy_Rb.AddForce(lookDirecton.normalized * speed);
    }
}
