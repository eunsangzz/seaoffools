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
        if(GameManager.Instance.isBattle == true)
        {
            StartCoroutine(bgSpawn());
        }
    }

    IEnumerator bgSpawn()
    {
        Debug.Log("1");
        int rand = Random.Range(0, 3);
        Instantiate(bg[rand], BgSpawner.position, BgSpawner.rotation);

        while(true)
        {
            int rand1 = Random.Range(0, 3);
            yield return new WaitForSeconds(38f);
            Instantiate(bg[rand1], BgSpawner.position, BgSpawner.rotation);
        }
    }
}
