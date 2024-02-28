using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject[] Cannon;
    public GameObject[] bulletPos;
    public GameObject bulletPre;
    public float reroadTime;

    private float shotTime;

    private bool shoot = false;

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
    }

    void ActiveCannon()
    {
        if (GameManager.Instance.isCannon1 == true)
        {
            Cannon[0].GetComponent<Move>().enabled = true;
            FireCannon(0);
        }
        else
        {
            Cannon[0].GetComponent<Move>().enabled = false;
        }
        if (GameManager.Instance.isCannon2 == true)
        {
            Cannon[1].GetComponent<Move>().enabled = true;
            FireCannon(1);
        }
        else
        {
            Cannon[1].GetComponent<Move>().enabled = false;
        }

        if (GameManager.Instance.isCannon3 == true)
        {
            Cannon[2].GetComponent<Move>().enabled = true;
            FireCannon(2);
        }
        else
        {
            Cannon[2].GetComponent<Move>().enabled = false;
        }

        if (GameManager.Instance.isCannon4 == true)
        {
            Cannon[3].GetComponent<Move>().enabled = true;
            FireCannon(3);
        }
        else
        {
            Cannon[3].GetComponent<Move>().enabled = false;
        }
    }



    void FireCannon(int barrelNum)
    {
        if (Input.GetMouseButtonDown(0) && shoot == false)
        {
            Vector3 mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject bullet = Instantiate(bulletPre, bulletPos[barrelNum].transform.position, Quaternion.identity);
            shoot = true;
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(3f);
        shoot = false;
    }
}
