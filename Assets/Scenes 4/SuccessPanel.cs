using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    public GameObject UISuccessPanel;
    public GameObject UIFailPanel;

    public Lifebar Lifebar;  //引入Lifebar血条脚本

    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (EnemyManager.Instance.enemyCount == 0 && EnemyManager.Instance.currentWaveIndex >= 2)
        {
            UISuccessPanel.SetActive(true);
        }

        if (Lifebar.sli.value == 0)
        {
            UIFailPanel.SetActive(true);
        }
    }
}
