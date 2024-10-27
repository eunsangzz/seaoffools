using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MarketUi : MonoBehaviour
{
    public GameObject shop;
    public GameObject marketUi;

    public AudioClip[] Btn;
    public GameObject[] SoldOut;

    public TextMeshProUGUI GoldText;

    private void Update()
    {
        marketOpen();
        if(GameManager.Instance.isHok == true)
        {
            SoldOut[1].SetActive(true);
        }
        if (GameManager.Instance.isWorm == true)
        {
            SoldOut[0].SetActive(true);
        }
        if(GameManager.Instance.isJuice1 == true)
        {
            SoldOut[3].SetActive(true);
        }
        if(GameManager.Instance.isJuice2 == true)
        {
            SoldOut[4].SetActive(true);
        }
    }

    public void BuyBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        if (clickObject.name == "CaveJuice1Btn" && GameManager.Instance.Gold >= 50 && GameManager.Instance.isJuice1 == false)
        {
            GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 50;
            GameManager.Instance.isJuice1 = true;
            SoldOut[3].SetActive(true);
        }
        if (clickObject.name == "CaveJuice2Btn" && GameManager.Instance.Gold >= 50 && GameManager.Instance.isJuice2 == false)
        {
            GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 50;
            GameManager.Instance.isJuice2 = true;
            SoldOut[4].SetActive(true);
        }
        if (clickObject.name == "HokBtn" && GameManager.Instance.Gold >= 300 && GameManager.Instance.isHok == false)
        {
            GameManager.Instance.Damage = GameManager.Instance.Damage * 2;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 300;
            GameManager.Instance.isHok = true;
            SoldOut[1].SetActive(true);
            
        }
        if (clickObject.name == "WormBtn" && GameManager.Instance.Gold >= 400 && GameManager.Instance.isWorm == false)
        {
            GameManager.Instance.AttackSpeed = 0.7f;
            GameManager.Instance.Gold = GameManager.Instance.Gold - 400;
            GameManager.Instance.isWorm = true;
            SoldOut[0].SetActive(true);
        }
    }

    public void shopBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        shop.SetActive(true);
    }

    public void ExitBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        SceneManager.LoadScene("LoadingScene");
        GameManager.Instance.Round += 1;
    }

    void marketOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            marketUi.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        GoldText.text = GameManager.Instance.Gold + " G";
    }
}
