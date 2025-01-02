using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success2 : MonoBehaviour
{
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public Lifebar Lifebar;
    public int LimitedTime = 5000;  //ͨ������ʱ��,50��λ�൱��1s
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
        if (Duration > LimitedTime || Lifebar.sli.value == 0)  //��ʱ����������Ϸ����
        {
            FailFlag.SetActive(true);
        }
        if (GetInfo)//�õ���������ͼ
        {
            SuccessFlag.SetActive(true);
        }
    }
}
