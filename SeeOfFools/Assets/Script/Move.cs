using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour //���� ����
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

    //���콺 �������� ������ �ٶ󺸵���
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

    void cannonMove() //���� �¿� �̵�
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

    void movement() //�̵�����
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }

    void MousePositionLimit(Vector3 mousePos, float minX, float maxX, float Y) //���콺 �̵�����
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
