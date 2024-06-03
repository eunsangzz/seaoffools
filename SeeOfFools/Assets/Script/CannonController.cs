using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject[] Cannon;
    public GameObject bulletPos;
    public GameObject[] bulletPre;
    public float reroadTime;

    private float shotTime;

    private bool shoot = false;
    

    // Update is called once per frame
    void Update()
    {
        ActiveCannon();
    }

    void ActiveCannon() //대포 작동
    {
        if (GameManager.Instance.isCannon1 == true)
        {
            Cannon[0].GetComponent<Move>().enabled = true;
            FireCannon();
        }
        else
        {
            Cannon[0].GetComponent<Move>().enabled = false;
        }
        
    }



    void FireCannon() //대포 발사
    {
        if (Input.GetMouseButtonDown(0) && shoot == false)
        {
            Vector3 mouPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if((Cannon[0].transform.position.x - 3) < mouPos.x && mouPos.x < (Cannon[0].transform.position.x + 3))// 대포발사 각도제한
            {
                if(GameManager.Instance.isWorm != true && GameManager.Instance.isHok != true)
                {
                    Instantiate(bulletPre[0], bulletPos.transform.position, Quaternion.identity); //총알 생성
                }
                if(GameManager.Instance.isWorm == true && GameManager.Instance.isHok != true)
                {
                    Instantiate(bulletPre[1], bulletPos.transform.position, Quaternion.identity); //총알 생성
                }
                if(GameManager.Instance.isHok == true && GameManager.Instance.isWorm != true)
                {
                    Instantiate(bulletPre[2], bulletPos.transform.position, Quaternion.identity); //총알 생성
                }
                if(GameManager.Instance.isWorm == true && GameManager.Instance.isHok == true)
                {
                    Instantiate(bulletPre[3], bulletPos.transform.position, Quaternion.identity); //총알 생성
                }
                shoot = true;
                StartCoroutine(ShootDelay());
            }
        }
    }

    IEnumerator ShootDelay() //재장전
    {
        yield return new WaitForSeconds(GameManager.Instance.AttackSpeed);
        shoot = false;
    }
}
