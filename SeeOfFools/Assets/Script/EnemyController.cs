using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public Animator anim;
    public EnemyType type;
    public Stat stat;

    private float speed = 0.3f;

    SpriteRenderer render;

    private bool dead = false;

    public GameObject hitEffect;

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

        yield return new WaitForSeconds(6f);

        GameManager.Instance.shipHp -= (stat.Damage / GameManager.Instance.Defense) + (stat.Damage % GameManager.Instance.Defense);

        yield return new WaitForSeconds(13f);

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
            stat.curhp -= GameManager.Instance.Damage;
        }
    }

    IEnumerator changeColor()
    {
        hitEffect.SetActive(true);
        render.color = new Color(1, 0, 0, 1);

        yield return new WaitForSeconds(0.5f);
        hitEffect.SetActive(false);
        render.color = new Color(1, 1, 1, 1);

        StopCoroutine(changeColor());
    }

    IEnumerator Dead()
    {
        dead = false;
        hitEffect.SetActive(true);
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        hitEffect.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Score += stat.Score;
        GameManager.Instance.Gold += stat.Gold;
        Destroy(gameObject);
    }
}
