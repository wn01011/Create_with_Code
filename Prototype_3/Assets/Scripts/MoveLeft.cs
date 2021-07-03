using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x < -10 && !CompareTag("BackGround"))
        {
            Destroy(gameObject);
        }
    }
    
}
