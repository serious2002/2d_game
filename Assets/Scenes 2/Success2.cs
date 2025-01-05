using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success2 : MonoBehaviour
{
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public Lifebar Lifebar;
    public int LimitedTime = 1000;  //通关限制时间,50单位相当于1s
    public int Duration;
    public Vector2 targetPosition = new Vector2(-9.5f, -3f);
    public float tolerance = 0.5f;
    void Start()
    {
        Duration = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Duration++;
        float distance = Vector2.Distance(transform.position, targetPosition);
        if (Duration > LimitedTime || Lifebar.sli.value == 0)  //超时或者死亡游戏结束
        {
            FailFlag.SetActive(true);
        }
        if (distance<tolerance)//拿到兵力部署图
        {
            SuccessFlag.SetActive(true);
        }
    }
}
