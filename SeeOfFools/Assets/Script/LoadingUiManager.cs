using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUiManager : MonoBehaviour
{
    public GameObject stage1Img;
    public GameObject stage2Img;
    public GameObject stage3Img;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Round == 1)
        {
            stage1Img.SetActive(true);
            stage2Img.SetActive(false);
            stage3Img.SetActive(false);
        }
        if(GameManager.Instance.Round == 2)
        {
            stage1Img.SetActive(false);
            stage2Img.SetActive(true);
            stage3Img.SetActive(false);
        }
        if(GameManager.Instance.Round == 3)
        {
            stage1Img.SetActive(false);
            stage2Img.SetActive(false);
            stage3Img.SetActive(true);
        }
    }
}
