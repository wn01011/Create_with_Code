using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [UnityEngine.Range(0,1000)]
    [SerializeField] private float speed = 800.0f;
    Vector3 dir = Vector3.zero;
    float timer = 0f;
    public bool isDie = false;
    private void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        PlayerMove();
    }


    private Vector3 MoveDir()
    {
        float verti = Input.GetAxisRaw("Vertical");
        float hori = Input.GetAxisRaw("Horizontal");
        dir.x = hori; dir.z = verti;
        dir.Normalize();
        return dir;
    }
    private void PlayerMove()
    {
        playerRb.velocity = speed * Time.deltaTime * MoveDir();
    }

    public void Die()
    {
        Debug.Log("You Die!\nScore :" + timer);
        gameObject.SetActive(false);
        isDie = true;
    }
}
