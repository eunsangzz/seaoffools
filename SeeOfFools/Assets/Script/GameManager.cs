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
            GameManager.Instance.isCannon1 = false;
        }
    }

    IEnumerator Battle()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.isBattle = true;
        GameManager.Instance.isMove = true;
        StopCoroutine(Battle());
    }

}

