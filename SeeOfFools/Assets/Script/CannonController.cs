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
    }

    // Update is called once per frame
    void Update()
    {
        ActiveCannon();
    }

    void ActiveCannon() //���� �۵�
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
        
    }



    void FireCannon(int barrelNum) //���� �߻�
    {
        if (Input.GetMouseButtonDown(0) && shoot == false)
        {
            Vector3 mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if((Cannon[0].transform.position.x - 3) < mouPos.x && mouPos.x < (Cannon[0].transform.position.x + 3))// �����߻� ��������
            {
                Instantiate(bulletPre, bulletPos[barrelNum].transform.position, Quaternion.identity); //�Ѿ� ����
                shoot = true;
                StartCoroutine(ShootDelay());
            }
        }
    }

    IEnumerator ShootDelay() //������
    {
        yield return new WaitForSeconds(1.5f);
        shoot = false;
    }
}
