using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour //대포 동작
{
    private Camera mainCamera;

    public float speed = 5;

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
            MousePositionLimit(mousePos, (thisPos.x - 2), (thisPos.x + 2), -1.0f);
        }

    }

    void cannonMove() //대포 좌우 이동
    {
        if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -1.2f)
        {
            movement();
        }
        else if (Input.GetKey(KeyCode.D) && this.transform.position.x <= 0.7f)
        {
            movement();
        }
    }

    void movement() //이동관련
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }

    void MousePositionLimit(Vector3 mousePos, float minX, float maxX, float Y) //마우스 이동제한
    {
        if(GameManager.Instance.isCannon1 == true)
        {
            if (mousePos.x >= minX && mousePos.x <= maxX && mousePos.y >= Y)
            {
                Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
                transform.up = dir;
            }
        }
    }
}
