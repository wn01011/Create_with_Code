using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Player_Rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();
        DashTimer();
        PlayerDash();
        RotToMouseDir();
        DoublePower();
        Shoot();
    }

    private void PlayerMove()
    {
        verti = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");
        transform.Translate(moveSpeed * Time.deltaTime * PlayerDir(), Space.World);
    }
    private void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dashCount >= 1)
        {
            Player_Rb.AddForce(PlayerDir().normalized * dashSpeed, ForceMode.Impulse);
            dashCount--;
        }
    }
    private void DashTimer()
    {
        if (dashCount < dashMax && dashTimer <= 0)
        {
            dashCount++;
            dashTimer = 2.0f;
        }
        else if (dashCount != dashMax)
        {
            dashTimer -= Time.deltaTime;
        }

    }
    private void RotToMouseDir()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitResult))
        {
            Vector3 mousedir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z);
            transform.LookAt(mousedir);
            //transform.forward = mousedir;
        }
    }
    private Vector3 PlayerDir()
    {
        Vector3 dir = new Vector3(hori, 0, verti);
        if (Vector3.Magnitude(dir) > 1)
            dir = dir.normalized;
        return dir;
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            isFireOn = true;
            _ = Instantiate(bullet, transform.position, transform.rotation);
        }
        DoubleShoot();
    }
    private void DoubleShoot()
    {
        if(isFireOn && isDoubleOn)
        {
            doubleshotTimer -= Time.deltaTime;
            if (doubleshotTimer < 0)
            {
                _ = Instantiate(bullet, transform.position, transform.rotation);
                doubleshotTimer = 0.2f;
                isFireOn = false;
            }
        }
    }
    private void DoublePower()
    {
        if (isDoubleOn && doubleTimer<0)
        {
            isDoubleOn = false;
            doubleTimer = 5.0f;
        }
        else if(isDoubleOn)
        {
            doubleTimer -= Time.deltaTime;
        }
    }
    

    float verti, hori;
    float moveSpeed = 10.0f;
    public int dashCount = 2;
    int dashMax = 2;
    int dashSpeed = 2000;
    public float dashTimer = 2.0f;
    private Rigidbody Player_Rb;
    public GameObject bullet;
    public bool isDoubleOn = false;
    public bool isFireOn = false;
    private float doubleTimer = 5.0f;
    public float doubleshotTimer = 0.2f;
    public bool isDead = false;
}