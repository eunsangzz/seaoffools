using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawn : MonoBehaviour
{
    public GameObject[] bg;
    public Transform BgSpawner;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isBattle == true)
        {
            StartCoroutine(bgSpawn());
            GameManager.Instance.isBattle = false;
        }
    }

    IEnumerator bgSpawn()
    {
        while(true)
        {
            int rand1 = Random.Range(0, 3);
            yield return new WaitForSeconds(40f);
            Instantiate(bg[rand1], BgSpawner.position, BgSpawner.rotation);
        }
    }
}
