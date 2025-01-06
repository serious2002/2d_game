using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Success2 : MonoBehaviour
{
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public Lifebar Lifebar;
    public float LimitedTime = 40f;
    public float Duration;
    public Vector2 targetPosition = new Vector2(-9.5f, -3f);
    public float tolerance = 0.5f;
    public GUIStyle timeStyle;
    void Start()
    {
        timeStyle = new GUIStyle();
        timeStyle.fontSize = 30;
        timeStyle.normal.textColor = Color.black;
        Duration = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Duration+=0.02f;
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
    private void OnGUI()
    {
        GUI.Label(new Rect(300, 20, 400, 50), $"时间：{(int)Duration}/{LimitedTime}", timeStyle);
    }
}
