using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MarketUi : MonoBehaviour
{
    public GameObject shop;
    public GameObject marketUi;

    private void Update()
    {
        marketOpen();
    }

    public void BuyBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.name == "CaveJuiceBtn" && GameManager.Instance.Gold >= 20)
        {
            GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 20;
        }
        if (clickObject.name == "HokBtn" && GameManager.Instance.Gold >= 50)
        {
            GameManager.Instance.Damage = GameManager.Instance.Damage * 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 50;
        }
        if (clickObject.name == "WormBtn" && GameManager.Instance.Gold >= 100)
        {
            GameManager.Instance.AttackSpeed = GameManager.Instance.AttackSpeed / 2 + GameManager.Instance.AttackSpeed % 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 100;
        }
        if (clickObject.name == "WormBtn" && GameManager.Instance.Gold >= 100)
        {
            GameManager.Instance.Defense = GameManager.Instance.Defense * 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 100;
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
