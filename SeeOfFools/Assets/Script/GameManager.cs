using UnityEngine;

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
    public bool isCannon2;
    public bool isCannon3;
    public bool isCannon4;
    public bool isBattle;
    public bool isMove;

    public float shipHp;

    void Start()
    {
        shipHp = 100f;
        isCannon1 = false;
        isCannon2 = false;
        isCannon3 = false;
        isCannon4 = false;
        isBattle = false;
        isMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
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

    public void battleStart() //지금은 버튼으로 작동
    {
        isBattle = true;
        isMove = true;
    }
}

