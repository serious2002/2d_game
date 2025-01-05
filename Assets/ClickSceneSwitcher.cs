using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSceneSwitcher : MonoBehaviour
{
    public string sceneName; // ��Ҫ�л����ĳ�������

    void Update()
    {
        // �������������¼�
        if (Input.GetMouseButtonDown(0))
        {
            // ����ָ���ĳ���
            SceneManager.LoadScene(sceneName);
        }
    }
}
