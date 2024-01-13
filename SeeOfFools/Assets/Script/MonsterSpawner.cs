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

        if (randEnemy >= 6) 
        { enemyType = 0; }
        if (randEnemy <= 8 && randEnemy >= 7)
        { enemyType = 1; }
        if (randEnemy >= 9)
        { enemyType = 2; }

        if(randY == 0)
        {
            randPos = new Vector3(Random.Range(-2.5f, 2.5f), 4f);
        }
        else
        {
            randPos = new Vector3(Random.Range(-2.5f, 2.5f), -4f);
        }

        yield return new WaitForSeconds(8f);

        Instantiate(enemy[enemyType], randPos, Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
