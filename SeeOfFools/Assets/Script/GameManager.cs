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

    void Start()
    {
        MaxHp = 10f;
        shipHp = 10f;
        isCannon1 = false;
        isBattle = false;
        isMove = false;
        isUp = false;
        isStory = false;
        isStart = false;
        Score = 0;
        Gold = 0;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        InactiveCannon();

        if(scene.name == "MainScene")
        {
            StartCoroutine(Battle());
        }
    }



    void InactiveCannon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isCannon1 = false;
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
        isBattle = false;
        isMove = false;
        isCannon1 = false;
        SceneManager.LoadScene("Market");
    }
}

