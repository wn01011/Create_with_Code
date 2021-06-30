using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public bool fireInput;
    public float walkSpeed = 20.0f;

    public float xRange = 10.0f; // x����� �Ѱ� ���� ����

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
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); // ���� fireinput�� �ԷµǸ� Instantiate�� �̿��ؼ� prefab�� ������ ��ġ���� ������ ȸ������ ������     
        }

        
    }
}
