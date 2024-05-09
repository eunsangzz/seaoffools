using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SavePointUiManager : MonoBehaviour
{
    public GameObject player;
    public GameObject naiting;
    public GameObject brooks;
    public GameObject smithUi;
    public GameObject upgradeUi;
    public GameObject storyUi;


    public TextMeshProUGUI brooksText;
    public TextMeshProUGUI naitingText;
    public TextMeshProUGUI jackText;

    int brooksTextNum;
    int naitingTextNum;


    void Start()
    {
        brooksTextNum = 0;
        naitingTextNum = 0;
    }

    void Update()
    {
        if(GameManager.Instance.isUp == true)
        {
            brooksInteraction();
        }
        if(GameManager.Instance.isStory == true)
        {
            naitingInteraction();
        }
    }

    void brooksInteraction() //무슨역할인지 아직 모름
    {
        brooksTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        naiting.SetActive(false);
        smithUi.SetActive(true);
    }

    void naitingInteraction() //todo -> 진행상황에 따라 다른 대사 출력, 진행상황 저장은 게임메니져스크립트에서
    {
        naitingTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        brooks.SetActive(false);
        storyUi.SetActive(true);
    }

    public void ExitBtn() //todo 대화 종료버튼 누를시 브룩은 대사 한번하고 종료
    {
        brooks.SetActive(true);
        naiting.SetActive(true);
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

    public void brooksBtn()
    {
        StartCoroutine(endInter());
    }

    public void naitingBtn()
    {
        if (naitingTextNum == 0)
        {
            naitingTextNum += 1;
            return;
        }
        if (naitingTextNum == 1)
        {
            naitingTextNum += 1;
            return;
        }
        if (naitingTextNum == 2)
        {
            naitingTextNum += 1;
            return;
        }
        if (naitingTextNum == 3) StartCoroutine(naitingInter());
    }

    private void LateUpdate()
    {
        if (brooksTextNum == 0)
        {
            brooksText.text = "Ah, Jack! Is it time to upgrade our ship?";
        }
        if (brooksTextNum == 1)
        {
            brooksText.text = "see you soon!";
        }

        if (naitingTextNum == 0) naitingText.text = "That was a hell of storm..";
        if (naitingTextNum == 1) naitingText.text = "It was a miracle we made it back";
        if (naitingTextNum == 2) naitingText.text = "It's good to brooks still waorking, we almost get stuck in this island";
        if (naitingTextNum == 3) naitingText.text = "Gonna try saving the rest the crew";
        if (naitingTextNum == 4) naitingText.text = "....";
    }

    IEnumerator endInter()
    {
        brooksTextNum = 1;
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        brooks.SetActive(true);
        naiting.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
        storyUi.SetActive(false);

        brooksTextNum = 0;
        StopCoroutine(endInter());
    }

    IEnumerator naitingInter()
    {
        naitingTextNum += 1;
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        brooks.SetActive(true);
        naiting.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
        storyUi.SetActive(false);

        naitingTextNum = 0;
        StopCoroutine(naitingInter());
    }
}
