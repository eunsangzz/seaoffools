using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartSceneUIManager : MonoBehaviour
{
    public void PlayBtn()
    {
        GetComponent<AudioSource>().Play();
        GameManager.Instance.isPlay = true;
        StartCoroutine(startGame());
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void CreditBtn()
    {
        SceneManager.LoadScene("CreditScene");
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("IntroScene");
    }
}
