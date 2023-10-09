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

    public bool isReadyCannon;

    public GameObject[] Cannon;

    void Start()
    {
        isCannon1 = false;
        isCannon2 = false;
        isCannon3 = false;
        isCannon4 = false;
        Cannon[0].GetComponent<Move>().enabled = false;
        Cannon[1].GetComponent<Move>().enabled = false;
        Cannon[2].GetComponent<Move>().enabled = false;
        Cannon[3].GetComponent<Move>().enabled = false;
    }

    void Update()
    {
        ActiveCannon();
        InactiveCannon();
    }

    void ActiveCannon()
    {
        if (isCannon1 == true)
        {
            Cannon[0].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[0].GetComponent<Move>().enabled = false;
        }
        if (isCannon2 == true)
        {
            Cannon[1].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[1].GetComponent<Move>().enabled = false;
        }

        if (isCannon3 == true)
        {
            Cannon[2].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[2].GetComponent<Move>().enabled = false;
        }

        if (isCannon4 == true)
        {
            Cannon[3].GetComponent<Move>().enabled = true;
        }
        else
        {
            Cannon[3].GetComponent<Move>().enabled = false;
        }
    }

    void InactiveCannon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Press");
            isCannon1 = false;
            isCannon2 = false;
            isCannon3 = false;
            isCannon4 = false;
        }
    }
}

