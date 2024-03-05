using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 mouPos;
    public float speed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, mouPos * 2, 0.01f);
    }
}
 