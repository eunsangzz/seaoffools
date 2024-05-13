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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpBarSlider.value = GameManager.Instance.shipHp / GameManager.Instance.MaxHp;
    }

    private void LateUpdate()
    {
        goldText.text = "" + GameManager.Instance.Gold;
        scoreText.text = "Score : " + GameManager.Instance.Score;
    }
}
