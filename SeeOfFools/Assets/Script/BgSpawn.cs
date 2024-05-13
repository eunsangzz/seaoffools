using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawn : MonoBehaviour
{
    public GameObject[] bg;
    public Transform BgSpawner;

    void Start()
    {
        if (GameManager.Instance.isBattle == true)
        {
            StartCoroutine(bgSpawn());
        }
    }


    IEnumerator bgSpawn()
    {
        int rand1 = Random.Range(0, 3);
        yield return new WaitForSeconds(5f);
        Instantiate(bg[rand1], BgSpawner.position, BgSpawner.rotation);
        StopCoroutine(bgSpawn());
    }
}
