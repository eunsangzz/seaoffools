using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }

    void Next()
    {
        GameManager.Instance.isStart = false;
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Single);
    }
}
