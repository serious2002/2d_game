using UnityEngine;
using UnityEngine.UI; // 如果使用了UI弹窗
using UnityEngine.SceneManagement; // 用于场景管理

public class SceneLoader : MonoBehaviour
{
    public bool useClick = true; // 是否使用点击
    public bool useCollision = false; // 是否使用碰撞
    public bool goToNextScene = false; // 是否进入下一个场景
    public string nextSceneName = "NextScene"; // 下一个场景的名称
    public GameObject popup; // 弹窗的GameObject

    private void Update()
    {
        if (useClick && Input.GetMouseButtonDown(0)) // 检测鼠标左键点击
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
            // 碰撞逻辑在OnCollisionEnter中处理
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useCollision && collision.gameObject.CompareTag("Player")) // 假设玩家有“Player”标签
        {
            HandleInteraction();
        }
    }

    private void HandleInteraction()
    {
        if (popup != null)
        {
            popup.SetActive(true); // 显示弹窗
        }

        if (goToNextScene)
        {
            SceneManager.LoadScene(nextSceneName); // 加载下一个场景
        }
    }
}
