using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public Animator anim;
    public EnemyType type;
    public Stat stat;

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
    }

    IEnumerator Behavior()
    {
        StartCoroutine(Attack());

        yield return new WaitForSeconds(17f);

        Destroy(this.gameObject);
    }

    IEnumerator Attack() //8�ʿ� �ѹ��� ���� 2�����ݽ� �����
    {
        //TODO ���ݾִϸ��̼�

        yield return new WaitForSeconds(2f);

        GameManager.Instance.shipHp -= stat.Damage;

        yield return new WaitForSeconds(5f);

    }
    
    void Died()
    {
        if(stat.curhp <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
