using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator anim;

    float time;

    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
        anim = GetComponent<Animator>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time == 20)
        {
            GameManager.Instance.isSlow = true;
            anim.SetBool("isSpin", true);
        }
        if(GameManager.Instance.isSlow == true && GameManager.Instance.isRewind == true)
        {
            time = 0;
            GameManager.Instance.isSlow = false;
            GameManager.Instance.isRewind = false;
            anim.SetBool("isSpin", false);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        time += 1;
        StartCoroutine(timer());
    }
}
