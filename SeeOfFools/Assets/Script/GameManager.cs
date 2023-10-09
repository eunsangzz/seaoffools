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

    public float shipHp;

    void Start()
    {
        shipHp = 100f;
        isCannon1 = false;
        isCannon2 = false;
        isCannon3 = false;
        isCannon4 = false;
    }

    void Update()
    {
        InactiveCannon();
    }


    void InactiveCannon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Press");
            GameManager.Instance.isCannon1 = false;
            GameManager.Instance.isCannon2 = false;
            GameManager.Instance.isCannon3 = false;
            GameManager.Instance.isCannon4 = false;
        }
    }
}

