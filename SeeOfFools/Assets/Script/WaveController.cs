using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public SpriteRenderer shipSpriteRenderer;


    public float upMax;
    public float downMax;
    public float shipX;
    float currentPosition;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * direction;
        if (currentPosition >= upMax)
        {
            direction *= -1;
            currentPosition = upMax;
        }
        else if (currentPosition <= downMax)
        {
            direction *= -1;
            currentPosition = downMax;
        }

        transform.position = new Vector3(shipX, currentPosition, 0);
    }
}
