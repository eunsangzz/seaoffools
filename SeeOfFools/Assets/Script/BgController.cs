using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
   
    void Update()
    {
        if(GameManager.Instance.isMove == true)
        {
            gameObject.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 0.5f);
        }
    }
}
