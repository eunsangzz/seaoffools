using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
    public Slider HpBarSlider;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI scoreText;

    public Image disable;
    private float limiteTime;
    private float limiteTime_max;

    public GameObject pauseText;

    public GameObject bgImg1;
    public GameObject bgImg2;
    public GameObject bgImg3;

    public Image Panel;

    float time = 0f;
    float F_time = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
        if(GameManager.Instance.Round == 1)
        {
            bgImg1.SetActive(true);
            bgImg2.SetActive(false);
            bgImg3.SetActive(false);
        }
        if (GameManager.Instance.Round == 2)
        {
            bgImg1.SetActive(false);
            bgImg2.SetActive(true);
            bgImg3.SetActive(false);
        }
        if (GameManager.Instance.Round == 3)
        {
            bgImg1.SetActive(false);
            bgImg2.SetActive(false);
            bgImg3.SetActive(true);
        }

        limiteTime_max = GameManager.Instance.gameTime;
        limiteTime = limiteTime_max;

        StartCoroutine(Timer());
    }

    void Update()
    {
        HpBarSlider.value = GameManager.Instance.shipHp / GameManager.Instance.MaxHp;

        if(GameManager.Instance.isLose == true)
        {
            GameManager.Instance.isLose = false;
            StartCoroutine(Lose());
        }
        if(GameManager.Instance.isWin == true)
        {
            GameManager.Instance.isWin = false;
            StartCoroutine(Win());
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            pauseText.SetActive(true);
        }
        else if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            pauseText.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        goldText.text = "" + GameManager.Instance.Gold;
        scoreText.text = "Score : " + GameManager.Instance.Score;
    }

    IEnumerator Timer()
    {
        while (limiteTime > 0.0f)
        {
            limiteTime -= Time.deltaTime;
            disable.fillAmount = limiteTime / limiteTime_max;

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Win()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while(alpha.a <1f)
        {
            time += Time.deltaTime/F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0;

        if (GameManager.Instance.Round == 1 || GameManager.Instance.Round == 2)
        {
            SceneManager.LoadScene("WinScene");
        }
        if(GameManager.Instance.Round == 3)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    IEnumerator Lose()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime/F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0;
        SceneManager.LoadScene("LoseScene");
    }

    IEnumerator FadeIn()
    {
        Color alpha = Panel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0;
        Panel.gameObject.SetActive(false);

        //yield return new WaitForSeconds(2f);

        GameManager.Instance.isMove = true;
        GameManager.Instance.isBattle = true;

        StopCoroutine(FadeIn());
    }

}
