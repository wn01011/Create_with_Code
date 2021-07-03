using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem runningParticle;
    public AudioClip hopSound;
    public AudioSource audioSource;
    public AudioClip crashSound;

    private float jumpPower = 1800;
    public float gravity_Modifier;
    public float moveSpeed = 20f;
    public bool isOnGround = true;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity_Modifier;

        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameOver = false;

                
    }

    // Update is called once per frame
    void Update()
    {
      
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0); // fixed Player's rotation to 90degree;
        
       
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            runningParticle.Stop();
            audioSource.PlayOneShot(hopSound, 1f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runningParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);

            explosionParticle.Play();
            runningParticle.Stop();
            audioSource.PlayOneShot(crashSound);
        }
    }
}
