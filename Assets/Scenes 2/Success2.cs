using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Success2 : MonoBehaviour
{
    public GameObject player;
    public GameObject SuccessFlag;
    public GameObject FailFlag;
    public Lifebar Lifebar;
    public float LimitedTime = 40f;
    public float Duration;
    public Vector2 targetPosition = new Vector2(-9.5f, -3f);
    public float tolerance = 0.5f;
    public GUIStyle timeStyle;
    private string scenenamefail = "videoSceneFail";
    private bool isTaskCompleted = false;
    private string taskMessage = "";
    private bool showTaskMessage = false;
    public GUIStyle taskStyle;
    void Start()
    {
        timeStyle = new GUIStyle();
        timeStyle.fontSize = 30;
        timeStyle.normal.textColor = Color.black;
        Duration = 0;
        // 初始化样式
        taskStyle = new GUIStyle();
        taskStyle.fontSize = 50;
        taskStyle.alignment = TextAnchor.MiddleCenter;
        taskStyle.normal.textColor = Color.red;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Duration+=0.02f;
        float distance = Vector2.Distance(transform.position, targetPosition);
        if (Duration > LimitedTime || Lifebar.sli.value == 0)  //超时或者死亡游戏结束
        {
            FailFlag.SetActive(true);
            BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
            if (backgroundMusicManager != null)
            {
                backgroundMusicManager.StopMusic();
            }
        }
       
            // 实时检测玩家是否被销毁

        if (player == null )
        {
                TaskFailed(); // 玩家已被销毁，任务失败
                              //yield return new WaitForSeconds(1f);
                              // 加载场景

        }

        
        if (distance<tolerance)//拿到兵力部署图
        {
            SuccessFlag.SetActive(true);
            isTaskCompleted = true;
            BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
            if (backgroundMusicManager != null)
            {
                backgroundMusicManager.StopMusic();
            }
            SceneManager.LoadScene(4);

        }
    }
    private void TaskFailed()
    {
        taskMessage = "任务失败！";
        showTaskMessage = true;
        taskStyle.normal.textColor = Color.red; // 设置失败为红色
        
        isTaskCompleted = false; // 标记任务已完成
        SceneManager.LoadScene(8);
        BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
        if (backgroundMusicManager != null)
        {
            backgroundMusicManager.StopMusic();
        }
        Debug.Log("任务失败！");
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(600, 20, 700, 50), $"时间：{(int)Duration}/{LimitedTime}", timeStyle);
    }
    private void OnGUI1()
    {
        if (showTaskMessage)
        {
            // 显示任务结果在屏幕中央
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), taskMessage, taskStyle);
        }
    }
}
