using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Image[] Panel;
    float time = 0f;
    float F_time = 1f;

    //승리 패배 로딩창 전부 포함

    void Start()
    {
        Panel[0].gameObject.SetActive(false);
        Panel[1].gameObject.SetActive(false);
        Panel[2].gameObject.SetActive(false);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        if(GameManager.Instance.Round == 1)
        {
            Panel[0].gameObject.SetActive(true);
            Color alpha = Panel[0].color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel[0].color = alpha;
                yield return null;
            }

            time = 0f;

            yield return new WaitForSeconds(2f);

            while (alpha.a > 0f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(1, 0, time);
                Panel[0].color = alpha;
                yield return null;
            }
        }

        if (GameManager.Instance.Round == 2)
        {
            Panel[1].gameObject.SetActive(true);
            Color alpha = Panel[1].color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel[1].color = alpha;
                yield return null;
            }

            time = 0f;

            yield return new WaitForSeconds(2f);

            while (alpha.a > 0f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(1, 0, time);
                Panel[1].color = alpha;
                yield return null;
            }
        }
        if (GameManager.Instance.Round == 3)
        {
            Panel[2].gameObject.SetActive(true);
            Color alpha = Panel[2].color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);
                Panel[2].color = alpha;
                yield return null;
            }

            time = 0f;
            yield return new WaitForSeconds(2f);

            while (alpha.a > 0f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(1, 0, time);
                Panel[2].color = alpha;
                yield return null;
            }
        }

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "WinScene")
        {
            SceneManager.LoadScene("Market");
        }
        else if (scene.name == "LoseScene")
        {
            SceneManager.LoadScene("SavePoint");
        }
    }
}
