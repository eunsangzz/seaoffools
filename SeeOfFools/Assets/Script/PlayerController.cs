using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject manager;
    Vector3 pos;
    public float speed = 5;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (GameManager.Instance.isCannon1 == false && GameManager.Instance.isCannon2 == false
            && GameManager.Instance.isCannon3 == false && GameManager.Instance.isCannon4 == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.y -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cannon1")
        {
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("Do");
                GameManager.Instance.isCannon1 = true;
            }
        }
        if (collision.gameObject.name == "Cannon2")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon2 = true;
            }
        }
        if (collision.gameObject.name == "Cannon3")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon3 = true;
            }
        }
        if (collision.gameObject.name == "Cannon4")
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.Instance.isCannon4 = true;
            }
        }
    }
}
