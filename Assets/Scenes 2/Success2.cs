using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success2 : MonoBehaviour
{
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public Lifebar Lifebar;
    public int LimitedTime = 5000;  //通关限制时间,50单位相当于1s
    public int Duration;
    public bool GetInfo = false;
    void Start()
    {
        Duration = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Duration++;
        if (Duration > LimitedTime || Lifebar.sli.value == 0)  //超时或者死亡游戏结束
        {
            FailFlag.SetActive(true);
        }
        if (GetInfo)//拿到兵力部署图
        {
            SuccessFlag.SetActive(true);
        }
    }
}
