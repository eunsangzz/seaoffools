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
        //전투 시작
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

        //몬스터 타입 지정
        if (randEnemy >= 6) 
        { enemyType = 0; }
        if (randEnemy <= 8 && randEnemy >= 7)
        { enemyType = 1; }
        if (randEnemy >= 9)
        { enemyType = 2; }
        
        //몬스터 스폰위치 설정
        randPos = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(2f, 4f));
        
        //몬스터 생성 딜레이
        yield return new WaitForSeconds(5f);
        
        //몬스터 생성
        Instantiate(enemy[enemyType], randPos, Quaternion.identity);

        //종료까지 반복
        StartCoroutine(Spawn());
    }
}
