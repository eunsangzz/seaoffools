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

        if (GameManager.Instance.Round == 1)
        {
            bg[0].SetActive(true);
            bg[1].SetActive(false);
            bg[2].SetActive(false);
        }
        if (GameManager.Instance.Round == 2)
        {
            bg[0].SetActive(false);
            bg[1].SetActive(true);
            bg[2].SetActive(false);
        }
        if (GameManager.Instance.Round == 3)
        {
            bg[0].SetActive(false);
            bg[1].SetActive(false);
            bg[2].SetActive(true);
        }
    }


    IEnumerator bgSpawn()
    {
        yield return new WaitForSeconds(5f);
        if (GameManager.Instance.Round == 1)
        {
            Instantiate(bg[0], BgSpawner.position, BgSpawner.rotation);
        }
        if (GameManager.Instance.Round == 2)
        {
            Instantiate(bg[1], BgSpawner.position, BgSpawner.rotation);
        }
        if (GameManager.Instance.Round == 3)
        {
            Instantiate(bg[2], BgSpawner.position, BgSpawner.rotation);
        }
        StopCoroutine(bgSpawn());
    }
}
