using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartSceneUIManager : MonoBehaviour
{
    public void PlayBtn()
    {
        GameManager.Instance.isPlay = true;
        StartCoroutine(startGame());
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("SavePoint");
    }
}
