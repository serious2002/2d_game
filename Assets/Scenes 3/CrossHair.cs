using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrossHair : MonoBehaviour
{
    public GameObject Bullet;
    public InputActions inputActions;
    private float lastShootTime = 0f;  // ��¼�ϴη����ӵ���ʱ��
    public GameObject Success;
    [Header("UI����")]
    public GUIStyle taskStyle; // ��������ʾ��ʽ

    private string taskMessage = ""; // ��������Ϣ
    private bool showTaskMessage = false; // �Ƿ���ʾ������
    private bool isTaskCompleted = false; // ��������Ƿ��Ѿ���ɣ��ɹ���ʧ�ܣ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ�������Ļ�ϵ�λ��
        Vector3 mousePosition = Input.mousePosition;
        // ����Ļ����ת��Ϊ��������
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // ����׼�ĵ�λ��
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

        if(Input.GetButtonDown("Fire1") && Time.time >= lastShootTime + 0.5)
        {
            lastShootTime = Time.time;

            GameObject newBullet = GameObject.Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();

            // ��ȡ�ӵ��� Bullet �ű�������޸��˺�ֵ
            if (newBullet.TryGetComponent<bullet>(out var bulletScript))
            {
                bulletScript.damage = 100;  // �޸��ӵ����˺�ֵ
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Success" && !isTaskCompleted)
        {
            TaskSuccess();
        }
    }
    private void TaskSuccess()
    {
        taskMessage = "����ɹ���";
        taskStyle.normal.textColor = Color.green; // ���óɹ�Ϊ��ɫ
        showTaskMessage = true;
        isTaskCompleted = true; // ������������

        Debug.Log("����ɹ���");
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
