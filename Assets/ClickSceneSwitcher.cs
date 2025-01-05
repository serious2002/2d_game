using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSceneSwitcher : MonoBehaviour
{
    public string sceneName; // 需要切换到的场景名称

    void Update()
    {
        // 检测鼠标左键点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 加载指定的场景
            SceneManager.LoadScene(sceneName);
        }
    }
}
