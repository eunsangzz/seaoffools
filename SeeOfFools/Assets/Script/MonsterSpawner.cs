 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private float time;
    Vector3 randPos;
    int enemyType;
    bool isStart = true;


    void Start()
    {
    }

    void Update()
    {
        //���� ����
        if (isStart == true)
        {
            StartCoroutine(Spawn());
            time += Time.deltaTime;
            isStart = false;
        }

        if(time >= 180f)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn()
    { 
        int randY = Random.Range(0, 2);
        int randEnemy = Random.Range(0, 100);

        if(GameManager.Instance.Round == 1)
        {
            if (randEnemy <= 80)
            { enemyType = 0; }
            if (randEnemy >= 81)
            { enemyType = 1; }
        }
        if(GameManager.Instance.Round == 2)
        {
            if (randEnemy <= 60)
            { enemyType = 0; }
            if (randEnemy <= 94 && randEnemy >= 61)
            { enemyType = 1; }
            if (randEnemy >= 95)
            { enemyType = 2; }
        }
        if(GameManager.Instance.Round == 3)
        {
            if (randEnemy <= 70)
            { enemyType = 0; }
            if (randEnemy <= 90 && randEnemy >= 71)
            { enemyType = 1; }
            if (randEnemy >= 91)
            { enemyType = 2; }
        }
        
        //���� ������ġ ����
        randPos = new Vector3(Random.Range(-3f, 2f), Random.Range(2f, 4f));
        
        //���� ���� ������
        if(GameManager.Instance.Round == 1)
        {
            yield return new WaitForSeconds(4f);
        }
        else if(GameManager.Instance.Round == 2)
        {
            yield return new WaitForSeconds(2f);
        }
        else if(GameManager.Instance.Round == 3)
        {
            yield return new WaitForSeconds(1f);
        }
        
        //���� ����
        Instantiate(enemy[enemyType], randPos, Quaternion.identity);

        //������� �ݺ�
        StartCoroutine(Spawn());
    }
}
