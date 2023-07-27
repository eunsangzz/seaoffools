using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] enemy;
    int randEnemy;
    int randY;
    Vector3 randPos;


    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        randY = Random.Range(0, 2);
        randEnemy = Random.Range(0, 3);
        if(randY == 0)
        {
            randPos = new Vector3(Random.Range(-2.5f, 2.5f), 4f);
        }
        else
        {
            randPos = new Vector3(Random.Range(-2.5f, 2.5f), -4f);
        }

        yield return new WaitForSeconds(8f);

        Instantiate(enemy[randEnemy], randPos, Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
