using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public string playerTag = "Player"; // �������ı�ǩ
    public string message = "��Ҫһ��Կ��"; // ��ʾ��Ϣ
    private bool showMessage = false; // �Ƿ���ʾ��ʾ��Ϣ
    private float messageTimer = 0f; // ��ʾ��Ϣ��ʾ�ļ�ʱ��

    private Collider2D triggerCollider; // �ŵĴ�����

    private void Awake()
    {
        // ��ȡ�ŵĴ�������ײ��
        triggerCollider = GetComponent<Collider2D>();

        // ����Ƿ�ɹ���ȡ������
        if (triggerCollider == null || !triggerCollider.isTrigger)
        {
            Debug.LogError("δ�ҵ�����������ȷ���Ŷ������д������� Collider2D �ҹ�ѡ�� Is Trigger��");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ȷ�������������Ƿ������
        if (collision.CompareTag(playerTag))
        {
            // ��ȡ��ҵ� PropManager �ű�
            PropManager playerPropManager = collision.GetComponent<PropManager>();
            if (playerPropManager != null)
            {
                // ���Կ������
                if (playerPropManager.keyCount >= 1)
                {
                    Debug.Log("���ӵ��Կ�ף�����ͨ���ţ�");
                    CheckAndDisableColliders(); // ��鲢������ײ��
                }
                else
                {
                    Debug.Log("���û��Կ�ף��޷�ͨ���ţ�");
                    showMessage = true; // ��ʾ��ʾ��Ϣ
                    messageTimer = 2f; // ��ʾ��Ϣ��ʾ2��
                }
            }
        }
    }

    private void CheckAndDisableColliders()
    {
        // ��鴥�����Ӵ�������������
        Collider2D[] overlappingColliders = Physics2D.OverlapBoxAll(triggerCollider.bounds.center, triggerCollider.bounds.size, 0);

        foreach (var collider in overlappingColliders)
        {
            // �ж��Ƿ�����Ϊ "PhysicalCollider" ������
            if (collider.gameObject.name == "PhysicalCollider")
            {
                collider.enabled = false; // ������ײ���
                Debug.Log($"�������� {collider.gameObject.name} ����ײ�����");
            }
        }
    }

    private void Update()
    {
        // ����ʱ������ʾ��Ϣ
        if (showMessage)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                showMessage = false;
            }
        }
    }

    private void OnGUI()
    {
        if (showMessage)
        {
            // ����Ļ����ʾ��ʾ��Ϣ
            GUI.skin.label.fontSize = 30;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 300, 100), message);
        }
    }
}
