using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private float jumpPower = 1800;
    public float gravity_Modifier;
    private float horiInput;
    public float moveSpeed = 20f;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity_Modifier;
        
    }

    // Update is called once per frame
    void Update()
    {
       // horiInput = Input.GetAxisRaw("Horizontal");
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0); // fixed Player's rotation to 90degree;
        
       
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }
        
        
       // transform.Translate(horiInput * moveSpeed * Time.deltaTime * Vector3.forward);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
