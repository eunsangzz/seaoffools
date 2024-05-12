using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class SavePointUiManager : MonoBehaviour
{
    public GameObject player;
    public GameObject naiting;
    public GameObject brooks;
    public GameObject smithUi;
    public GameObject upgradeUi;
    public GameObject storyUi;
    public GameObject startBtn;

    public GameObject jackImg;
    public GameObject naitingImg;
    public GameObject brooksImg;


    public TextMeshProUGUI brooksText;

    public TextMeshProUGUI naitingText;
    public TextMeshProUGUI naitingNextText;

    public TextMeshProUGUI StartText;



    int brooksTextNum;
    int naitingTextNum;
    int startTextNum;


    void Start()
    {
        brooksTextNum = 0;
        naitingTextNum = 0;
        startTextNum = 0;
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

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name =="SavePoint")
        {
            if (GameManager.Instance.isStart == true)
            {
                startBtn.SetActive(true);
            }
            else
            {
                startBtn.SetActive(false);
            }
        }

    }

    void brooksInteraction() //������������ ���� ��
    {
        brooksTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        naiting.SetActive(false);
        smithUi.SetActive(true);
        GameManager.Instance.isUp = false;
    }

    void naitingInteraction() //todo -> �����Ȳ�� ���� �ٸ� ��� ���, �����Ȳ ������ ���Ӹ޴�����ũ��Ʈ����
    {
        naitingTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        naiting.SetActive(false);
        storyUi.SetActive(true);
        GameManager.Instance.isStory = false;
    }

    public void ExitBtn() //todo ��ȭ �����ư ������ ����� ��� �ѹ��ϰ� ����
    {
        brooks.SetActive(true);
        naiting.SetActive(true);
        player.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
        storyUi.SetActive(false);
    }

    public void upgradeUiBtn()
    {
        smithUi.SetActive(false);
        upgradeUi.SetActive(true);
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

    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        GameManager.Instance.isStart = false;
    }

    private void LateUpdate()
    {
        if (brooksTextNum == 0)
        {
            brooksText.text = "Ah, Jack! Is it time to upgrade our ship?";
        }
        else
        {
            brooksText.text = "see you soon!";
        }

        if (naitingTextNum == 0) naitingText.text = "That was a hell of storm..";
        if (naitingTextNum == 1) naitingText.text = "It was a miracle we made it back";
        if (naitingTextNum == 2) naitingText.text = "It's good to brooks still waorking, we almost get stuck in this island";
        if (naitingTextNum == 3)
        {
            naitingText.text = "Gonna try saving the rest the crew";
            naitingNextText.text = "Exit";
            
        }
        if (naitingTextNum == 4) naitingText.text = "....";

        if (startTextNum == 0) StartText.text = "Brooks! is the ship ready to go?";
        if (startTextNum == 1) StartText.text = "Not as it used to be but it works";
        if (startTextNum == 2) StartText.text = "We still need lot more part to go far out in the sea";
        if (startTextNum == 3) StartText.text = "Why don't you take some from your head?";
        if (startTextNum == 4) StartText.text = "Anyway, It's time to sail once again!";
    }

    IEnumerator endInter()
    {
        brooksTextNum = 1;
        Debug.Log("Change");
        yield return new WaitForSeconds(1f);
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
        yield return new WaitForSeconds(1f);
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
