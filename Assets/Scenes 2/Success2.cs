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

        if (player == null && !isTaskCompleted && use_fail)
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
        taskStyle.normal.textColor = Color.red; // ����ʧ��Ϊ��ɫ
        showTaskMessage = true;
        isTaskCompleted = false; // ������������
        SceneManager.LoadScene(scenenamefail);
        BackgroundMusicManager backgroundMusicManager = FindObjectOfType<BackgroundMusicManager>();
        if (backgroundMusicManager != null)
        {
            backgroundMusicManager.StopMusic();
        }
        Debug.Log("����ʧ�ܣ�");
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(300, 20, 400, 50), $"ʱ�䣺{(int)Duration}/{LimitedTime}", timeStyle);
    }
}
