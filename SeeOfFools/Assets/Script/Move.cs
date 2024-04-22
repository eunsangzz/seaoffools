using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Camera mainCamera;

    public float speed = 5;
    Vector3 pos;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CannonRotate();
        cannonMove();
    }

    //마우스 방향으로 포신이 바라보도록
    void CannonRotate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 thisPos = this.gameObject.transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if(GameManager.Instance.isCannon1 == true)
        {
            MousePositionLimit(mousePos, (thisPos.x - 2), (thisPos.x + 2), 2.0f);
        }
        if(GameManager.Instance.isCannon2 == true)
        {
            MousePositionLimit(mousePos, -0, 6, 3.5f);
        }
        if(GameManager.Instance.isCannon3 == true)
        {
            MousePositionLimit(mousePos, -6, 0, -3.5f);
        }
        if(GameManager.Instance.isCannon4 == true)
        {
            MousePositionLimit(mousePos, -0, 6, -3.5f);
        }


        //Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //transform.up = dir;

    }

    void cannonMove()
    {
        if (Input.GetKey(KeyCode.A) && pos.x >= -2.8f)
        {
            pos.x -= speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && pos.x <= 2.8f)
        {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void MousePositionLimit(Vector3 mousePos, float minX, float maxX, float Y)
    {
        if(GameManager.Instance.isCannon1 == true || GameManager.Instance.isCannon2 == true)
        {
            if (mousePos.x >= minX && mousePos.x <= maxX && mousePos.y >= Y)
            {
                Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
                transform.up = dir;
            }
        }

        if (GameManager.Instance.isCannon3 == true || GameManager.Instance.isCannon4 == true)
        {
            if (mousePos.x >= minX && mousePos.x <= maxX && mousePos.y <= Y)
            {
                Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
                transform.up = dir;
            }
        }
    }
}
