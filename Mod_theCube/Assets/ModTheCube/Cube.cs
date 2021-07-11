using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Vector3 my_Vec;
    public float startDelay = 1.0f;
    public float repeatTime = 2f;
    public Rigidbody box_Rb;

    void Start()
    {
        Material material = Renderer.material;
        box_Rb = GetComponent<Rigidbody>();
        InvokeRepeating("changeMaterial", startDelay, repeatTime);
        InvokeRepeating("changeScale", startDelay, repeatTime);
        InvokeRepeating("changePosition", startDelay, repeatTime);
    }

    void Update()
    {
        AddForce();
        float speed = Random.Range(0.5f, 10.0f);
        float angleX = Random.Range(-0.30f, 30.0f);
        float angleY = Random.Range(-0.10f, 10.0f);
        float angleZ = Random.Range(-0.90f, 90.0f);
        transform.Rotate(angleX * Time.deltaTime * speed, angleY * Time.deltaTime * speed, angleZ * Time.deltaTime * speed);
    }

    void changeMaterial()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        float a = Random.Range(0.0f, 1.0f);
        Renderer.material.color = new Color(r, g, b, a);
    }

    void changeScale()
    {
        float x = Random.Range(0.5f, 4.0f);
        transform.localScale = Vector3.one * x;
    }

    void changePosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        transform.position = new Vector3(x, y, z);
    }
    void AddForce()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        my_Vec = new Vector3(10 * x, 10 * y,10 * z);
        box_Rb.velocity = my_Vec;
    }
}
