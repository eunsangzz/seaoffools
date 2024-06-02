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

    private void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        HpBarSlider.value = GameManager.Instance.shipHp / GameManager.Instance.MaxHp;
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
}
