using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 pos;
    public float speed = 5;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
