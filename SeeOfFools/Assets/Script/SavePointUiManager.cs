using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SavePointUiManager : MonoBehaviour
{

    public GameObject smith;
    public GameObject storyNpc;
    public GameObject upgrade;
    public GameObject smithUi;
    public GameObject upgradeUi;


    void Start()
    {

    }

    void Update()
    {

    }

    public void SmithBtn() //무슨역할인지 아직 모름
    {
        smith.SetActive(false);
        storyNpc.SetActive(false);
        upgrade.SetActive(false);
        smithUi.SetActive(true);
    }

    public void StoryNpcBtn() //todo -> 진행상황에 따라 다른 대사 출력, 진행상황 저장은 게임메니져스크립트에서
    {

    }

    public void UpgradeBtn()
    {
        smith.SetActive(false);
        storyNpc.SetActive(false);
        upgradeUi.SetActive(true);
    }

    public void SmithExitBtn()
    {
        smith.SetActive(true);
        storyNpc.SetActive(true);
        upgrade.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
    }

    public void upgradeBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        if(clickObject.name == "Attack")
        {

        }
        else if(clickObject.name == "Health")
        {

        }
        else if(clickObject.name == "Defense")
        {

        }
    }

}
