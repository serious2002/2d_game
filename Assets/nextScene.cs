using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // 引入用于协程的命名空间

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName; // 需要切换到的场景名称

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadSceneWithDelay(sceneName));
        }
    }

    // 协程方法，用于延迟加载场景
    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // 等待一秒
        yield return new WaitForSeconds(1f);
        // 加载场景
        SceneManager.LoadScene(sceneName);
    }
}
