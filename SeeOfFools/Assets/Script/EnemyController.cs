using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public Animator anim;
    public EnemyType type;
    public Stat stat;

    private float speed = 0.1f;

    SpriteRenderer render;

    private bool dead = false;

    void Awake()
    {
        stat = new Stat();
        anim = GetComponent<Animator>();
        stat = stat.SetEnemyStat(type);
    }

    void Start()
    {
        StartCoroutine(Behavior());
        render = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 current = this.transform.position;

        current.y -= speed * Time.deltaTime;
        this.transform.position = current;

        Died();
    }

    IEnumerator Behavior() //TODO 몬스터 공격루틴, 애니메이션, 사망이벤트(배에 몸박고 죽는다, 시간마다 공격후 배와 충돌시 죽는다.)
    {

        yield return new WaitForSeconds(5f);

        GameManager.Instance.shipHp -= 2f;

        yield return new WaitForSeconds(15f);

        Destroy(this.gameObject);
    }
    
    void Died()
    {
        if(stat.curhp <= 0)
        {
            dead = true;
        }
        if(dead == true)
        {
            StartCoroutine(Dead());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            if(stat.curhp > 1.1f)
            {
                StartCoroutine(changeColor());
            }
            stat.curhp -= 1;
        }
    }

    IEnumerator changeColor()
    {
        render.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.5f);

        render.color = new Color(1, 1, 1, 1);

        StopCoroutine(changeColor());
    }

    IEnumerator Dead()
    {
        dead = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
