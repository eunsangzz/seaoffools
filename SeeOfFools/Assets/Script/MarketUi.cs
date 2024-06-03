using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MarketUi : MonoBehaviour
{
    public GameObject shop;
    public GameObject marketUi;

    public GameObject hokSoldOut;
    public GameObject wormSoldOut;
    public GameObject juiceSoldOut;
    public GameObject juice2SoldOut;

    private void Update()
    {
        marketOpen();
    }

    public void BuyBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.name == "CaveJuice1Btn" && GameManager.Instance.Gold >= 20 && GameManager.Instance.isJuice1 == false)
        {
            GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 20;
            GameManager.Instance.isJuice1 = true;
            juiceSoldOut.SetActive(true);
        }
        if (clickObject.name == "CaveJuice2Btn" && GameManager.Instance.Gold >= 20 && GameManager.Instance.isJuice2 == false)
        {
            GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 20;
            GameManager.Instance.isJuice2 = true;
            juice2SoldOut.SetActive(true);
        }
        if (clickObject.name == "HokBtn" && GameManager.Instance.Gold >= 50 && GameManager.Instance.isHok == false)
        {
            GameManager.Instance.Damage = GameManager.Instance.Damage * 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 50;
            GameManager.Instance.isHok = true;
            hokSoldOut.SetActive(true);
            
        }
        if (clickObject.name == "WormBtn" && GameManager.Instance.Gold >= 100 && GameManager.Instance.isWorm == false)
        {
            GameManager.Instance.AttackSpeed = GameManager.Instance.AttackSpeed / 2 + GameManager.Instance.AttackSpeed % 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 100;
            GameManager.Instance.isWorm = true;
            wormSoldOut.SetActive(true);
        }
    }

    public void shopBtn()
    {
        shop.SetActive(true);
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.Round += 1;
    }

    void marketOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            marketUi.SetActive(true);
        }
    }
}
