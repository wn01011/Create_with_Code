using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hopping : MonoBehaviour
{
    private Rigidbody target_Rb;
    private Vector3 ranTorq;
    private float MaxTorq = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        target_Rb = GetComponent<Rigidbody>();
        target_Rb.AddForce(Vector3.up * Random.Range(5.0f, 15.0f), ForceMode.Impulse);
        target_Rb.AddTorque(RanTorq(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    private Vector3 RanTorq()
    {
        float x = Random.Range(-MaxTorq, MaxTorq);
        float y = Random.Range(-MaxTorq, MaxTorq);
        float z = Random.Range(-MaxTorq, MaxTorq);
        ranTorq = new Vector3(x,y,z);

        return ranTorq;
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
   





}
