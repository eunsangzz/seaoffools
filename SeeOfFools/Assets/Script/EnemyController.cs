using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public Animator anim;
    public EnemyType type;
    public Stat stat;

    private float speed = 1.0f;

    void Awake()
    {
        stat = new Stat();
        anim = GetComponent<Animator>();
        stat = stat.SetEnemyStat(type);
    }

    void Start()
    {
        StartCoroutine(Behavior());
    }

    void Update()
    {
        Vector3 current = this.transform.position;

        current.y -= speed * Time.deltaTime;
        this.transform.position = current;

        Died();
    }

    IEnumerator Behavior() //TODO ���� ���ݷ�ƾ, �ִϸ��̼�, ����̺�Ʈ(�迡 ���ڰ� �״´�, �ð����� ������ ��� �浹�� �״´�.)
    {

        yield return new WaitForSeconds(2f);

        GameManager.Instance.shipHp -= 2f;

        yield return new WaitForSeconds(6f);

        Destroy(this.gameObject);
    }
    
    void Died()
    {
        if(stat.curhp <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        if(collision.tag == "Bullet")
        {
            stat.curhp -= 1;
            Destroy(collision);
            Debug.Log(stat.curhp);
        }
    }
}
