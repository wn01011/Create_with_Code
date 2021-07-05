using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vertiInput;
    private float moveSpeed = 3.0f;
    private Transform player_Pos;
    private Transform start_Pos;
    private RotateCamera rot_Camera;
    private Rigidbody player_Rb;
    public bool gameOver;
    public bool PowerUp;
    private float powerUpStrength = 20f;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        PowerUp = false;
        gameOver = false;
        player_Pos = GetComponent<Transform>();
        player_Rb = GetComponent<Rigidbody>();
        start_Pos = player_Pos;
        rot_Camera = GameObject.Find("Focal Point").GetComponent<RotateCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        
        vertiInput = Input.GetAxis("Vertical");

        player_Pos.transform.position = start_Pos.transform.position;
        player_Rb.AddForce(rot_Camera.transform.forward * moveSpeed * vertiInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, 2, 0);

        if (transform.position.y < 0)
        {
            gameOver = true;
        }

        //transform.Rotate(Vector3.up * rot_Camera.rotInput * Time.deltaTime );
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            PowerUp = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && PowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer.normalized * powerUpStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(7.0f);
        PowerUp = false;
        powerupIndicator.SetActive(false);
    }
}
