using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MarketUi : MonoBehaviour
{
    public void BuyBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if (clickObject.name == "CaveJuiceBtn" && GameManager.Instance.Gold >= 10)
        {

        }
        if (clickObject.name == "HokBtn" && GameManager.Instance.Gold >= 10)
        {

        }
        if (clickObject.name == "WormBtn" && GameManager.Instance.Gold >= 10)
        {

        }
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.Instance.Round += 1;
    }
}
