using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // ��������Э�̵������ռ�

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName; // ��Ҫ�л����ĳ�������

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadSceneWithDelay(sceneName));
        }
    }

    // Э�̷����������ӳټ��س���
    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // �ȴ�һ��
        yield return new WaitForSeconds(1f);
        // ���س���
        SceneManager.LoadScene(sceneName);
    }
}
