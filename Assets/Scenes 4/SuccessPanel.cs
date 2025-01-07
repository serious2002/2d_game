using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    public GameObject UISuccessPanel;
    public GameObject UIFailPanel;
    private string scenenamefail = "videoSceneFail";
    public Lifebar Lifebar;  //引入Lifebar血条脚本

    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (EnemyManager_4.Instance.enemyCount == 0 && EnemyManager_4.Instance.currentWaveIndex >= 2)
        {
            UISuccessPanel.SetActive(true);
            SceneManager.LoadScene(10);
        }

        if (Lifebar.sli.value == 0)
        {
            UIFailPanel.SetActive(true);
            SceneManager.LoadScene(scenenamefail);
        }
    }
}
