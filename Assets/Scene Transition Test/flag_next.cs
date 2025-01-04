using UnityEngine;
using UnityEngine.UI; // ���ʹ����UI����
using UnityEngine.SceneManagement; // ���ڳ�������

public class SceneLoader : MonoBehaviour
{
    public bool useClick = true; // �Ƿ�ʹ�õ��
    public bool useCollision = false; // �Ƿ�ʹ����ײ
    public bool goToNextScene = false; // �Ƿ������һ������
    public string nextSceneName = "NextScene"; // ��һ������������
    public GameObject popup; // ������GameObject

    private void Update()
    {
        if (useClick && Input.GetMouseButtonDown(0)) // ������������
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    HandleInteraction();
                }
            }
        }

        if (useCollision)
        {
            // ��ײ�߼���OnCollisionEnter�д���
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useCollision && collision.gameObject.CompareTag("Player")) // ��������С�Player����ǩ
        {
            HandleInteraction();
        }
    }

    private void HandleInteraction()
    {
        if (popup != null)
        {
            popup.SetActive(true); // ��ʾ����
        }

        if (goToNextScene)
        {
            SceneManager.LoadScene(nextSceneName); // ������һ������
        }
    }
}
