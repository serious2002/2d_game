using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public int LimitedTime = 1000;  //ͨ������ʱ��
    public Lifebar Lifebar;
    public int Duration;
    public bool GetInfo = false;
    void Start()
    {
        Duration = 0;
    }

    // Update is called once per frame
    void Update()
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
