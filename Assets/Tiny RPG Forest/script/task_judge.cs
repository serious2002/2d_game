using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalFlag : MonoBehaviour
{
    [Header("�������")]
    public GameObject player; // ��Ҷ������� Inspector ����ק����
    public bool use_fail = false;
    private string scenenamefail = "videoSceneFail";
    [Header("UI����")]
    public GUIStyle taskStyle; // ��������ʾ��ʽ

    private string taskMessage = ""; // ��������Ϣ
    private bool showTaskMessage = false; // �Ƿ���ʾ������
    private bool isTaskCompleted = false; // ��������Ƿ��Ѿ���ɣ��ɹ���ʧ�ܣ�
    

    private void Start()
    {
        // ��ʼ����ʽ
        taskStyle = new GUIStyle();
        taskStyle.fontSize = 50;
        taskStyle.alignment = TextAnchor.MiddleCenter;
        taskStyle.normal.textColor = Color.red;
    }

    private void Update()
    {
        // ʵʱ�������Ƿ�����
        
        if (player == null && !isTaskCompleted && use_fail)
            {
                TaskFailed(); // ����ѱ����٣�����ʧ��
                 //yield return new WaitForSeconds(1f);
                    // ���س���
                 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��鴥�����Ƿ������
        if (collision.CompareTag("Player") && !isTaskCompleted)
        {
            TaskSuccess(); // ��Ҵ��������죬����ɹ�
        }
    }

    private void TaskSuccess()
    {
        taskMessage = "����ɹ���";
        taskStyle.normal.textColor = Color.green; // ���óɹ�Ϊ��ɫ
        showTaskMessage = true;
        isTaskCompleted = true; // ������������
        BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
        if (backgroundMusicManager != null)
        {
            backgroundMusicManager.StopMusic();
        }
        Debug.Log("����ɹ���");
    }

    private void TaskFailed()
    {
        taskMessage = "����ʧ�ܣ�";
        taskStyle.normal.textColor = Color.red; // ����ʧ��Ϊ��ɫ
        showTaskMessage = true;
        isTaskCompleted = true; // ������������
        SceneManager.LoadScene(scenenamefail);

        Debug.Log("����ʧ�ܣ�");
    }

    private void OnGUI()
    {
        if (showTaskMessage)
        {
            // ��ʾ����������Ļ����
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), taskMessage, taskStyle);
        }
    }
}
