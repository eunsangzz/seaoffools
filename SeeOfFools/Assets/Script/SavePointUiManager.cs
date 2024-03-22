using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointUiManager : MonoBehaviour
{

    public GameObject smith;
    public GameObject storyNpc;
    public GameObject smithUi;
    public GameObject upgradeUi;


    void Start()
    {
        
    }

    void Update()
    {

    }

    public void SmithBtn()
    {
        smith.SetActive(false);
        storyNpc.SetActive(false);
        smithUi.SetActive(true);
    }

    public void StoryNpcBtn() //todo -> �����Ȳ�� ���� �ٸ� ��� ���, �����Ȳ ������ ���Ӹ޴�����ũ��Ʈ����
    {

    }

    public void UpgradeBtn()
    {
        smithUi.SetActive(false);
        upgradeUi.SetActive(true);
    }

    public void SmithExitBtn()
    {
        smith.SetActive(true);
        storyNpc.SetActive(true);
        smithUi.SetActive(false);
        upgradeUi.SetActive(false);
    }

}
