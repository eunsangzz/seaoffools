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
            Vector3 mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("1");
                GameObject touch = hit.transform.gameObject;
                if (touch.name == "Small Monster(Clone)" || touch.name == "Midium Monster(Clone)" || touch.name == "Elite Monster(Clone)")
                {
                    Debug.Log(touch.GetComponent<EnemyController>().stat.curhp);
                    touch.GetComponent<EnemyController>().stat.curhp -= 1;
                    Debug.Log(touch.GetComponent<EnemyController>().stat.curhp);
                }
            }

        }
    }
}
