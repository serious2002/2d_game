using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    public GameObject UISuccessPanel;
    public GameObject UIFailPanel;

    public Lifebar Lifebar;  //����LifebarѪ���ű�

    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (EnemyManager_4.Instance.enemyCount == 0 && EnemyManager_4.Instance.currentWaveIndex >= 2)
        {
            UISuccessPanel.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Lifebar.sli.value == 0)
        {
            UIFailPanel.SetActive(true);
        }
    }
}
