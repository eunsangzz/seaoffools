using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseUi : MonoBehaviour
{
    public RectTransform transform_cursor;
    public GameObject aim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isCannon1 == true)
        {
            aim.SetActive(true);
            Cursor.visible = false;
        }
        else
        {
            aim.SetActive(false);
            Cursor.visible = true;
        }

        Update_MousePosition();
    }


    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        transform_cursor.position = mousePos;
    }

}
