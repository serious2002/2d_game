using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public string playerTag = "Player"; // 玩家物体的标签
    public string message = "需要一把钥匙"; // 提示信息
    private bool showMessage = false; // 是否显示提示信息
    private float messageTimer = 0f; // 提示信息显示的计时器

    private Collider2D triggerCollider; // 门的触发器

    private void Awake()
    {
        // 获取门的触发器碰撞器
        triggerCollider = GetComponent<Collider2D>();

        // 检查是否成功获取触发器
        if (triggerCollider == null || !triggerCollider.isTrigger)
        {
            Debug.LogError("未找到触发器，请确保门对象上有触发器的 Collider2D 且勾选了 Is Trigger！");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 确认碰到的物体是否是玩家
        if (collision.CompareTag(playerTag))
        {
            // 获取玩家的 PropManager 脚本
            PropManager playerPropManager = collision.GetComponent<PropManager>();
            if (playerPropManager != null)
            {
                // 检查钥匙数量
                if (playerPropManager.keyCount >= 1)
                {
                    Debug.Log("玩家拥有钥匙，可以通过门！");
                    CheckAndDisableColliders(); // 检查并禁用碰撞器
                }
                else
                {
                    Debug.Log("玩家没有钥匙，无法通过门！");
                    showMessage = true; // 显示提示信息
                    messageTimer = 2f; // 提示信息显示2秒
                }
            }
        }
    }

    private void CheckAndDisableColliders()
    {
        // 检查触发器接触到的所有物体
        Collider2D[] overlappingColliders = Physics2D.OverlapBoxAll(triggerCollider.bounds.center, triggerCollider.bounds.size, 0);

        foreach (var collider in overlappingColliders)
        {
            // 判断是否是名为 "PhysicalCollider" 的物体
            if (collider.gameObject.name == "PhysicalCollider")
            {
                collider.enabled = false; // 禁用碰撞体积
                Debug.Log($"禁用物体 {collider.gameObject.name} 的碰撞体积！");
            }
        }
    }

    private void Update()
    {
        // 倒计时隐藏提示信息
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
            // 在屏幕上显示提示信息
            GUI.skin.label.fontSize = 30;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 300, 100), message);
        }
    }
}
