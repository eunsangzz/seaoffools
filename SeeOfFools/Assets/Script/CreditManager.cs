using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector2(0, 1) * Time.deltaTime * 3f);
    }

    public void Btn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
