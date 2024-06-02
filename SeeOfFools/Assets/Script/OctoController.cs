using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OctoController : MonoBehaviour
{
    public SpriteRenderer shipSpriteRenderer;


    public float rightMax;
    public float leftMax;
    public float shipX;
    float currentPosition;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position.x;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition += Time.deltaTime * direction;
        if (GameManager.Instance.isSlow == true)
        {
            direction = 0.15f;
       
        }
        if(GameManager.Instance.isSlow == false)
        {
            direction = - 0.15f;
        }
        if(GameManager.Instance.isSlow == false && currentPosition <=leftMax)
        {
            direction = 0;
        }

        transform.position = new Vector3(currentPosition, 0, 0);

        if(currentPosition >= rightMax)
        {
            GameManager.Instance.shipHp = 0.0f;
        }
    }
}
