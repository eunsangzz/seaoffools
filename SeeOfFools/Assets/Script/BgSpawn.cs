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
        yield return new WaitForSeconds(5f);
        if (GameManager.Instance.Round == 1)
        {
            Instantiate(bg[0], BgSpawner.position, BgSpawner.rotation);
        }
        if (GameManager.Instance.Round == 1)
        {
            Instantiate(bg[1], BgSpawner.position, BgSpawner.rotation);
        }
        if (GameManager.Instance.Round == 1)
        {
            Instantiate(bg[2], BgSpawner.position, BgSpawner.rotation);
        }
        StopCoroutine(bgSpawn());
    }
}
