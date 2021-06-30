using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public bool fireInput;
    public float walkSpeed = 20.0f;

    public float xRange = 10.0f; // x축방향 한계 범위 설정

    public GameObject projectilePrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * walkSpeed);

        fireInput = Input.GetKeyDown(KeyCode.Space);

        if (fireInput)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); // 만약 fireinput이 입력되면 Instantiate를 이용해서 prefab이 지정된 위치에서 지정된 회전으로 생성됨     
        }

        
    }
}
