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
    private float limiteTime = 60f;
    private float limiteTime_max = 60f;

    public GameObject pauseText;

    private void Start()
    {
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
