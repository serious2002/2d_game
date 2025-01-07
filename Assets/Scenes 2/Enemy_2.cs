using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制移动速度
    public Vector2 rectSize = new Vector2(10, 5); // 矩形的大小，x 为宽度，y 为高度

    private Vector2[] corners; // 矩形的四个角点
    private int currentCornerIndex = 0; // 当前目标角点的索引

    private Vector2 lastMoveDirection = Vector2.zero; // 记录上一次的移动方向

    private eye enemyEye; // 用于控制视野翻转

    private void Start()
    {
        // 获取 eye 组件（假设 eye 是 Enemy_2 的子对象）
        enemyEye = GetComponentInChildren<eye>();

        // 计算矩形的四个角点
        Vector2 center = transform.position; // 矩形中心为敌人初始位置
        corners = new Vector2[]
        {
            center + new Vector2(rectSize.x / 2, rectSize.y / 2), // 右上角
            center + new Vector2(-rectSize.x / 2, rectSize.y / 2), // 左上角
            center + new Vector2(-rectSize.x / 2, -rectSize.y / 2), // 左下角
            center + new Vector2(rectSize.x / 2, -rectSize.y / 2) // 右下角
        };
    }

    private void Update()
    {
        // 调用 Move 方法使敌人绕矩形移动
        Move();

        // 更新视野（eye）根据移动方向翻转
        if (enemyEye != null)
        {
            enemyEye.UpdateDirection(lastMoveDirection);
        }
    }

    private void Move()
    {
        // 获取当前目标角点
        Vector2 targetPosition = corners[currentCornerIndex];

        // 记录敌人移动的方向
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        lastMoveDirection = direction;

        // 使用 Vector2.MoveTowards 方法使敌人向目标角点移动，移动速度为 moveSpeed
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 如果敌人当前位置与目标角点的距离小于 0.1f，则认为敌人已经到达目标角点
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            // 当敌人到达目标角点时，更新目标角点的索引，使其指向下一个角点
            currentCornerIndex = (currentCornerIndex + 1) % corners.Length;
        }
    }

    private void OnDestroy()
    {
        if (EnemyManager_4.Instance != null)
        {
            EnemyManager_4.Instance.DecreaseEnemyCount();
        }
    }
}
