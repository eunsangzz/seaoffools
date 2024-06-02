using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    public bool isStart;

    public bool isCannon1;
    public bool isBattle;
    public bool isMove;
    public bool isUp;
    public bool isStory;
    public bool isSlow;
    public bool isRewind;
    public bool isPlay;

    public float shipHp;
    public float MaxHp;

    public int Gold;
    public int UpgradeGold1;
    public int UpgradeGold2;
    public int UpgradeGold3;
    public int UpgradeLv1;
    public int UpgradeLv2;
    public int UpgradeLv3;

    public int Score;
    public int Round;
    public float gameTime;

    public float Damage;
    public float Defense;
    public float AttackSpeed;

    private int num;
    public bool first;

    void Start()
    {
        MaxHp = 200f;
        shipHp = 200f;
        Score = 0;
        Gold = 200;

        Damage = 4.0f;
        Defense = 1.0f;
        AttackSpeed = 1.5f;

        num = 0;
        Round = 1;
        gameTime = 60f;

        UpgradeGold1 = 100;
        UpgradeGold2 = 100;
        UpgradeGold3 = 100;
        UpgradeLv1 = 1;
        UpgradeLv2 = 1;
        UpgradeLv3 = 1;


        isPlay = false;
        isCannon1 = false;
        isBattle = false;
        isMove = false;
        isUp = false;
        isStory = false;
        isStart = false;
        first = true;
        isSlow = false;
        isRewind = false;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        InactiveCannon();
        Lose();

        if (scene.name == "MainScene" && num == 0) 
        {
            num = 1;
            StartCoroutine(Battle());
        }
        if(scene.name == "SavePoint")
        {
            isMove = true;
            Cursor.visible = true;
        }
        if(scene.name == "Market")
        {
            isBattle = false;
            isMove = false;
            isCannon1 = false;
            Cursor.visible = true;
        }
        if (isCannon1 == false)
        {
            Cursor.visible = true;
        }
    }



    void InactiveCannon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isCannon1 = false;
        }
    }


    void Lose()
    {
        if(shipHp <= 0.0f)
        {
            StopCoroutine(GameStart());
            SceneManager.LoadScene("SavePoint");
            shipHp = MaxHp;
            Damage = 4.0f;
            Defense = 1.0f;
            AttackSpeed = 1.5f;
            Round = 1;
        }
    }

    IEnumerator Battle()
    {
        yield return new WaitForSeconds(2f);
        isBattle = true;
        isMove = true;
        StartCoroutine(GameStart()); 
        StopCoroutine(Battle());
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(60f);
        if(Round <= 2 && shipHp >= 0.0f)
        {
            SceneManager.LoadScene("Market");
            num = 0;
            StopCoroutine(GameStart());
        }
        else if(Round >= 3)
        {
            Application.Quit();
        }
    }
}

