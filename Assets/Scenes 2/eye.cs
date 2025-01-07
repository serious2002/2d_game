using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject player;
    private float originalRotation; // 保存原始角度

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalRotation = transform.rotation.eulerAngles.z; // 获取初始旋转角度
    }

    // 根据敌人移动方向更新视野的旋转和镜像翻转
    public void UpdateDirection(Vector2 moveDirection)
    {
        // 计算敌人的朝向
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        // 将视野（eye）的旋转设置为敌人移动的方向
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + originalRotation));

        // 根据移动方向交换 xy 位置
        if (moveDirection.x > 0.1)  // 向右
        {
            // 向右移动时，保持原有的位置
            transform.localPosition = new Vector3(3, 0, 0);
            sr.flipY = false;  // 向右时，不需要 Y 翻转
        }
        else if (moveDirection.x < -0.1)  // 向左
        {
            // 向左移动时，交换 x 和 y 坐标
            transform.localPosition = new Vector3(-3, 0, 0);
            sr.flipY = false;  // 向左时，不需要 Y 翻转
        }

        // 根据移动方向来翻转 Y 轴（垂直）
        if (moveDirection.y > 0.1)  // 向上
        {
            // 向上移动时，交换 x 和 y 坐标
            transform.localPosition = new Vector3(0, 3, 0);
            sr.flipY = false;  // 向上时，不需要 Y 翻转
        }
        else if (moveDirection.y < -0.1)  // 向下
        {
            // 向下移动时，交换 x 和 y 坐标
            transform.localPosition = new Vector3(0, -3, 0);
            sr.flipY = false;  // 向下时，需要 Y 翻转
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player2")
        {
            player.TryGetComponent<Player>(out var playerScript);
            if (playerScript != null) {
                playerScript.TakeDamage(100);
            }
        }
    }
}
