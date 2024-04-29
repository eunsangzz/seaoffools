using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] enemy;
    private float time;
    Vector3 randPos;
    int enemyType;
    bool isStart = false;


    void Start()
    {
        
    }

    void Update()
    {
        //���� ����
        if(GameManager.Instance.isBattle == true)
        {
            StartCoroutine(Spawn());
            isStart = true;
            GameManager.Instance.isBattle = false;
        }

        if (isStart == true)
        {
            time += Time.deltaTime;
        }

        if(time >= 180f)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn()
    {
        int randY = Random.Range(0, 2);
        int randEnemy = Random.Range(0, 10);

        //���� Ÿ�� ����
        if (randEnemy >= 6) 
        { enemyType = 0; }
        if (randEnemy <= 8 && randEnemy >= 7)
        { enemyType = 1; }
        if (randEnemy >= 9)
        { enemyType = 2; }
        
        //���� ������ġ ����
        randPos = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(2f, 4f));
        
        //���� ���� ������
        yield return new WaitForSeconds(5f);
        
        //���� ����
        Instantiate(enemy[enemyType], randPos, Quaternion.identity);

        //������� �ݺ�
        StartCoroutine(Spawn());
    }
}
