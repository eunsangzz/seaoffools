using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject[] Cannon;

    void Start()
    {
        Cannon[0].GetComponent<Move>().enabled = false;
        Cannon[1].GetComponent<Move>().enabled = false;
        Cannon[2].GetComponent<Move>().enabled = false;
        Cannon[3].GetComponent<Move>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveCannon();
        AttackCannon();
    }

    void ActiveCannon()
    {
        if (GameManager.Instance.isCannon1 == true)
        {
            Cannon[0].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[0].GetComponent<Move>().enabled = false;
        }
        if (GameManager.Instance.isCannon2 == true)
        {
            Cannon[1].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[1].GetComponent<Move>().enabled = false;
        }

        if (GameManager.Instance.isCannon3 == true)
        {
            Cannon[2].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[2].GetComponent<Move>().enabled = false;
        }

        if (GameManager.Instance.isCannon4 == true)
        {
            Cannon[3].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[3].GetComponent<Move>().enabled = false;
        }
    }

    void AttackCannon()
    {
        if (GameManager.Instance.isCannon1 == true || GameManager.Instance.isCannon2 == true ||
            GameManager.Instance.isCannon3 == true || GameManager.Instance.isCannon4 == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                Debug.Log(mouPos);
            }
        }
    }
}
