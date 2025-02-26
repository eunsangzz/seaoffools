using System.Collections;
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
    public bool isLose;
    public bool isWin;

    public bool isCannon1;
    public bool isBattle;
    public bool isMove;
    public bool isUp;
    public bool isStory;
    public bool isSlow;
    public bool isRewind;
    public bool isPlay;

    public bool isHok;
    public bool isWorm;
    public bool isJuice1;
    public bool isJuice2;

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
    public bool tuto;

    void Start()
    {
        MaxHp = 200f;
        shipHp = MaxHp;
        Score = 0;
        Gold = 100;

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

        isWin = false;
        isLose = false;

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

        isHok = false;
        isWorm = false;
        isJuice2 = false;
        isJuice1 = false;

        tuto = true;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        InactiveCannon();
        Lose();

        if (scene.name == "MainScene" && num == 0)
        {
            num = 1;
        }
        if (scene.name == "SavePoint")
        {
            isMove = true;
            Cursor.visible = true;
        }
        if (scene.name == "Market")
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
        if (shipHp <= 0.0f)
        {
            SceneManager.LoadScene("LoseScene");
            isLose = true;
            shipHp = MaxHp;
            Damage = 4.0f;
            Defense = 1.0f;
            AttackSpeed = 1.5f;
            isHok = false;
            isWorm = false;
            isJuice2 = false;
            isJuice1 = false;
            Round = 1;
        }
    }
}

