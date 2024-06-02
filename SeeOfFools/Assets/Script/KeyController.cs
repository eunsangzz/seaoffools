using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    float time;

    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(timer());
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 20)
        {
            GameManager.Instance.isSlow = true;
        }
        if(GameManager.Instance.isSlow == true && GameManager.Instance.isRewind == true)
        {
            time = 0;
            GameManager.Instance.isSlow = false;
            GameManager.Instance.isRewind = false;
        }
        if (time % 2 == 0 && GameManager.Instance.isSlow == false)
        {
            rend.flipX = false;
        }
        else if (time % 2 == 1 && GameManager.Instance.isSlow == false)
        {
            rend.flipX = true;
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        time += 1;
        StartCoroutine(timer());
    }
}
