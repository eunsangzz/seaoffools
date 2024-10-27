using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroUiManager : MonoBehaviour
{

    public GameObject[] Img;

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<7;i++)
        {
            Img[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        IntroOpen();
    }

    void IntroOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Img[i].SetActive(true);
            i++;
        }
    }

    public void NextBtn()
    {
        SceneManager.LoadScene("SavePoint");
    }

}
