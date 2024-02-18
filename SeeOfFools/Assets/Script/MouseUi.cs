using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseUi : MonoBehaviour
{
    public RectTransform transform_cursor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isCannon1 == true || GameManager.Instance.isCannon2 == true
            || GameManager.Instance.isCannon3 == true || GameManager.Instance.isCannon4 == true)
        {
            Init_Cursor();
        }
        Update_MousePosition();
    }

    private void Init_Cursor()
    {
        Cursor.visible = false;
        transform_cursor.pivot = Vector2.up;

        if (transform_cursor.GetComponent<Graphic>())
            transform_cursor.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        transform_cursor.position = mousePos;
    }

}
