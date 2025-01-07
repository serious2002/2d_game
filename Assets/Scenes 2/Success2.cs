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
        // ��ʼ����ʽ
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
        if (Duration > LimitedTime || Lifebar.sli.value == 0)  //��ʱ����������Ϸ����
        {
            FailFlag.SetActive(true);
            BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
            if (backgroundMusicManager != null)
            {
                backgroundMusicManager.StopMusic();
            }
        }
       
            // ʵʱ�������Ƿ�����

        if (player == null )
        {
                TaskFailed(); // ����ѱ����٣�����ʧ��
                              //yield return new WaitForSeconds(1f);
                              // ���س���

        }

        
        if (distance<tolerance)//�õ���������ͼ
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
        taskMessage = "����ʧ�ܣ�";
        showTaskMessage = true;
        taskStyle.normal.textColor = Color.red; // ����ʧ��Ϊ��ɫ
        
        isTaskCompleted = false; // ������������
        SceneManager.LoadScene(8);
        BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
        if (backgroundMusicManager != null)
        {
            backgroundMusicManager.StopMusic();
        }
        Debug.Log("����ʧ�ܣ�");
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(600, 20, 700, 50), $"ʱ�䣺{(int)Duration}/{LimitedTime}", timeStyle);
    }
    private void OnGUI1()
    {
        if (showTaskMessage)
        {
            // ��ʾ����������Ļ����
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), taskMessage, taskStyle);
        }
    }
}
