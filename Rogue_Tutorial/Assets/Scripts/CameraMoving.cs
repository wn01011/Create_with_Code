using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void LateUpdate()
    {
        if (Player.GetComponent<PlayerController>().isDead == false)
        { CameraMove(); }
    }
    void CameraMove()
    {
        if(Mathf.Abs(Player.transform.position.x) <= 25 && Mathf.Abs(Player.transform.position.z) <= 25)
        {
            transform.position = Player.transform.position + offset;
        }
        else if(Mathf.Abs(Player.transform.position.x) > 25 && Mathf.Abs(Player.transform.position.z) <= 25)
        {
            if (Player.transform.position.x > 0)
                transform.position = new Vector3(25, Player.transform.position.y, Player.transform.position.z) + offset;
            else
                transform.position = new Vector3(-25, Player.transform.position.y, Player.transform.position.z) + offset;
        }
        else if (Mathf.Abs(Player.transform.position.x) <= 25 && Mathf.Abs(Player.transform.position.z) > 25)
        {
            if (Player.transform.position.z > 0)
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 25) + offset;
            else
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -25) + offset;
        }
    }

    private GameObject Player;
    private Vector3 offset = new Vector3(0, 20, -10);
}
