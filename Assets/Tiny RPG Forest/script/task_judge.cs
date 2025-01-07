using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlag : MonoBehaviour
{
    [Header("玩家引用")]
    public GameObject player; // 玩家对象，需在 Inspector 中拖拽引用
    public bool use_fail = false;
    private string scenenamefail = "videoSceneFail";
    [Header("UI设置")]
    public GUIStyle taskStyle; // 任务结果显示样式

    private string taskMessage = ""; // 任务结果信息
    private bool showTaskMessage = false; // 是否显示任务结果
    private bool isTaskCompleted = false; // 标记任务是否已经完成（成功或失败）
    

    private void Start()
    {
        // 初始化样式
        taskStyle = new GUIStyle();
        taskStyle.fontSize = 50;
        taskStyle.alignment = TextAnchor.MiddleCenter;
        taskStyle.normal.textColor = Color.red;
    }

    private void Update()
    {
        // 实时检测玩家是否被销毁
        
        if (player == null && !isTaskCompleted && use_fail)
            {
                TaskFailed(); // 玩家已被销毁，任务失败
                 //yield return new WaitForSeconds(1f);
                    // 加载场景
                 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检查触碰的是否是玩家
        if (collision.CompareTag("Player") && !isTaskCompleted)
        {
            TaskSuccess(); // 玩家存活并触碰红旗，任务成功
        }
    }

    private void TaskSuccess()
    {
        taskMessage = "任务成功！";
        taskStyle.normal.textColor = Color.green; // 设置成功为绿色
        showTaskMessage = true;
        isTaskCompleted = true; // 标记任务已完成
        BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
        if (backgroundMusicManager != null)
        {
            backgroundMusicManager.StopMusic();
        }
        Debug.Log("任务成功！");
    }

    private void TaskFailed()
    {
        taskMessage = "任务失败！";
        taskStyle.normal.textColor = Color.red; // 设置失败为红色
        showTaskMessage = true;
        isTaskCompleted = true; // 标记任务已完成
        SceneManager.LoadScene(scenenamefail);

        Debug.Log("任务失败！");
    }

    private void OnGUI()
    {
        if (showTaskMessage)
        {
            // 显示任务结果在屏幕中央
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), taskMessage, taskStyle);
        }
    }
}
