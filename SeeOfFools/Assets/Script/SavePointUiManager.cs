using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SavePointUiManager : MonoBehaviour
{
    public GameObject player;
    public GameObject naiting;
    public GameObject brooks;
    public GameObject smithUi;
    public GameObject upgradeUi;
    public GameObject storyUi;
    public GameObject startUi;
    public GameObject startBtn;

    public GameObject jackImg;
    public GameObject naitingImg;
    public GameObject brooksImg;


    public TextMeshProUGUI brooksText;

    public TextMeshProUGUI naitingText;
    public TextMeshProUGUI naitingNextText;

    public TextMeshProUGUI StartText;
    public TextMeshProUGUI StartNeztText;
    public TextMeshProUGUI StartNameText;

    public TextMeshProUGUI AttackLvText;
    public TextMeshProUGUI HealthLvText;
    public TextMeshProUGUI SpeedLvText;

    public TextMeshProUGUI AttackGoldText;
    public TextMeshProUGUI HealthGoldText;
    public TextMeshProUGUI SpeedGoldText;

    public TextMeshProUGUI goldText;

    public AudioClip[] Btn;

    public GameObject[] needGold;

    int brooksTextNum;
    int naitingTextNum;
    int startTextNum;

    private void Awake()
    {

    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        brooksTextNum = 0;
        naitingTextNum = 0;
        startTextNum = 0;
        if (scene.name == "SavePoint" && GameManager.Instance.first == true)
        {
            player.SetActive(false);
            naiting.SetActive(false);
            brooks.SetActive(false);
            startUi.SetActive(true);
            GameManager.Instance.first = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.isUp == true)
        {
            brooksInteraction();
        }
        if (GameManager.Instance.isStory == true)
        {
            naitingInteraction();
        }

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "SavePoint")
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

    void brooksInteraction() //무슨역할인지 아직 모름
    {
        brooksTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        naiting.SetActive(false);
        smithUi.SetActive(true);
        GameManager.Instance.isUp = false;
    }

    void naitingInteraction() //todo -> 진행상황에 따라 다른 대사 출력, 진행상황 저장은 게임메니져스크립트에서
    {
        naitingTextNum = 0;
        player.SetActive(false);
        brooks.SetActive(false);
        naiting.SetActive(false);
        storyUi.SetActive(true);
        GameManager.Instance.isStory = false;
    }

    public void ExitBtn() //todo 대화 종료버튼 누를시 브룩은 대사 한번하고 종료
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        brooks.SetActive(true);
        naiting.SetActive(true);
        player.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
        storyUi.SetActive(false);
    }

    public void upgradeUiBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        smithUi.SetActive(false);
        upgradeUi.SetActive(true);
    }

    public void upgradeBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        if (clickObject.name == "Attack")
        {
            if (GameManager.Instance.Gold >= GameManager.Instance.UpgradeGold1)
            {
                GameManager.Instance.Gold = GameManager.Instance.Gold - GameManager.Instance.UpgradeGold1;
                GameManager.Instance.Damage += 1;
                GameManager.Instance.UpgradeGold1 += 50;
                GameManager.Instance.UpgradeLv1 += 1;
            }
            else
            {
                needGold[0].SetActive(true);
                StartCoroutine(NeedGold(0));
            }
        }
        else if (clickObject.name == "Health")
        {
            if (GameManager.Instance.Gold >= GameManager.Instance.UpgradeGold2)
            {
                GameManager.Instance.Gold = GameManager.Instance.Gold - GameManager.Instance.UpgradeGold2;
                GameManager.Instance.MaxHp += 10;
                GameManager.Instance.shipHp = GameManager.Instance.MaxHp;
                GameManager.Instance.UpgradeGold2 += 50;
                GameManager.Instance.UpgradeLv2 += 1;
            }
            else
            {
                needGold[1].SetActive(true);
                StartCoroutine(NeedGold(1));
            }
        }
        else if (clickObject.name == "Speed")
        {
            if (GameManager.Instance.Gold >= GameManager.Instance.UpgradeGold3)
            {
                GameManager.Instance.Gold = GameManager.Instance.Gold - GameManager.Instance.UpgradeGold3;
                GameManager.Instance.gameTime -= 5f;
                GameManager.Instance.UpgradeGold3 += 50;
                GameManager.Instance.UpgradeLv3 += 1;
            }
            else
            {
                needGold[2].SetActive(true);
                StartCoroutine(NeedGold(2));
            }
        }

    }

    public void brooksBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        StartCoroutine(endInter());
    }

    public void naitingBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        if (naitingTextNum == 0)
        {
            naitingTextNum += 1;
        }
        else if (naitingTextNum == 1)
        {
            naitingTextNum += 1;
        }
        else if (naitingTextNum == 2)
        {
            naitingTextNum += 1;
        }
        else if (naitingTextNum == 3) StartCoroutine(naitingInter());
    }

    public void startUiBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        if (startTextNum == 0)
        {
            startTextNum += 1;
        }
        else if (startTextNum == 1)
        {
            startTextNum += 1;
        }
        else if (startTextNum == 2)
        {
            startTextNum += 1;
        }
        else if (startTextNum == 3)
        {
            StartCoroutine(startInter());
        }
    }

    public void StartBtn()
    {
        AudioClip audio = Btn[0];
        GetComponent<AudioSource>().PlayOneShot(audio, 0.8f);
        if (GameManager.Instance.tuto == true)
        {
            GameManager.Instance.tuto = false;
            SceneManager.LoadScene("Tuto");
        }
        else
        {
            GameManager.Instance.isStart = false;
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
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

        if (startTextNum == 0)
        {
            StartText.text = "Brooks! is the ship ready to go?";
            StartNameText.text = "Jack";
            jackImg.SetActive(true);
            brooksImg.SetActive(false);
            naitingImg.SetActive(false);
        }
        if (startTextNum == 1)
        {
            StartText.text = "Not as it used to be but it works";
            StartNameText.text = "Brooks";
            jackImg.SetActive(false);
            brooksImg.SetActive(true);
            naitingImg.SetActive(false);
        }
        if (startTextNum == 2)
        {
            StartText.text = "We still need lot more part to go far out in the sea";
        }
        if (startTextNum == 3)
        {
            StartText.text = "Why don't you take some from your head?";
            StartNameText.text = "Naiting";
            jackImg.SetActive(false);
            brooksImg.SetActive(false);
            naitingImg.SetActive(true);
            StartNeztText.text = "Exit";
        }
        if (startTextNum == 4)
        {
            StartText.text = "Anyway, It's time to sail once again!";
            StartNameText.text = "Jack";
        }

        AttackLvText.text = "Lv." + GameManager.Instance.UpgradeLv1;
        HealthLvText.text = "Lv." + GameManager.Instance.UpgradeLv2;
        SpeedLvText.text = "Lv." + GameManager.Instance.UpgradeLv3;

        AttackGoldText.text = "" + GameManager.Instance.UpgradeGold1;
        HealthGoldText.text =  "" + GameManager.Instance.UpgradeGold2;
        SpeedGoldText.text =  "" + GameManager.Instance.UpgradeGold3;

        goldText.text = GameManager.Instance.Gold + " G";
    }

    IEnumerator endInter()
    {
        brooksTextNum = 1;
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

    IEnumerator startInter()
    {
        startTextNum += 1;
        jackImg.SetActive(true);
        brooksImg.SetActive(false);
        naitingImg.SetActive(false);
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        naiting.SetActive(true);
        brooks.SetActive(true);
        startUi.SetActive(false);
        StopCoroutine(startInter());
    }

    IEnumerator NeedGold(int i)
    {
        yield return new WaitForSeconds(2f);
        needGold[i].SetActive(false);
    }
}
