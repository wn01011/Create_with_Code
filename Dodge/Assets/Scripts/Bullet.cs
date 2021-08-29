using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [UnityEngine.Range(0,10)][SerializeField]
    private float speed = 8.0f;
    private Rigidbody bulletRb;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject != null)
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                playerController.Die();
            }
        }
        if(other.CompareTag("Wall"))
        {
            bulletRb.velocity *= -1;
        }
    }
}
