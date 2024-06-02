using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongControllwe : MonoBehaviour
{
    float currentPosition;

    private void Start()
    {
        currentPosition = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        //currentPosition += Time.deltaTime * 5;
        if (GameManager.Instance.isPlay == true)
        {
            currentPosition += Time.deltaTime * 10;
            transform.Rotate(0, 0, Time.deltaTime * 2000f, Space.Self);
        }
        transform.position = new Vector3(6.5f, currentPosition, 0);
    }
}
