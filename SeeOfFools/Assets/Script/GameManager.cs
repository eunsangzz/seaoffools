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



    public bool isCannon1;
    public bool isBattle;
    public bool isMove;
    public bool isUp;
    public bool isStory;

    public float shipHp;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        shipHp = 100f;
        isCannon1 = false;
        isBattle = false;
        isMove = false;
        isUp = false;
        isStory = false;

        if(scene.name == "MainScene")
        {
            StartCoroutine(Battle());
        }
    }

    void Update()
    {
        InactiveCannon();
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
        isBattle = true;
        isMove = true;
        StopCoroutine(Battle());
    }

}

