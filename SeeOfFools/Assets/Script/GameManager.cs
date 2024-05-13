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

    public float shipHp;
    public float MaxHp;

    public int Gold;
    public int Score;
    public int Round;

    public float Damage;
    public float Defense;

    private int num;
    public bool first;

    void Start()
    {
        MaxHp = 50f;
        shipHp = 50f;
        Score = 0;
        Gold = 0;

        Damage = 1.0f;
        Defense = 1.0f;

        num = 0;
        Round = 1;


        isCannon1 = false;
        isBattle = false;
        isMove = false;
        isUp = false;
        isStory = false;
        isStart = false;
        first = true;
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
        }
        if(scene.name == "Market")
        {
            isBattle = false;
            isMove = false;
            isCannon1 = false;
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
            SceneManager.LoadScene("SavePoint");
            shipHp = MaxHp;
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
        yield return new WaitForSeconds(5f);
        if(Round <= 2)
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

