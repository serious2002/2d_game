using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制移动速度
    public Vector2 rectSize = new Vector2(10, 5); // 矩形的大小, x为宽度, y为高度
    private SpriteRenderer spriteRenderer;
    private Vector2[] corners; // 矩形的四个角点
    private int currentCornerIndex = 0; // 当前目标角点的索引

    private Vector2 lastMoveDirection = Vector2.zero; // 记录上一次移动的方向

    private eye enemyEye; // 敌人的眼睛组件

    private void Start()
    {
        // 获取 SpriteRenderer 组件
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 获取 eye 组件
        enemyEye = GetComponentInChildren<eye>();

        // 计算矩形的四个角点
        Vector2 center = transform.position;
        corners = new Vector2[]
        {
            center + new Vector2(rectSize.x / 2, rectSize.y / 2), // 右上角
            center + new Vector2(-rectSize.x / 2, rectSize.y / 2), // 左上角
            center + new Vector2(-rectSize.x / 2, -rectSize.y / 2), // 左下角
            center + new Vector2(rectSize.x / 2, -rectSize.y / 2) // 右下角
        };
    }

    private void UpdateFacingDirection()
    {
        // 根据目标角点更新角色的朝向
        Vector2 targetPosition = corners[currentCornerIndex];
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        if (direction.x > 0) // 向右移动
        {
            spriteRenderer.flipX = false; // 朝右
        }
        else if (direction.x < 0) // 向左移动
        {
            spriteRenderer.flipX = true; // 朝左
        }
    }

    private void Update()
    {
        // 移动敌人
        Move();

        // 更新眼睛的方向
        if (enemyEye != null)
        {
            enemyEye.UpdateDirection(lastMoveDirection);
        }
    }

    private void Move()
    {
        // 获取当前目标角点
        Vector2 targetPosition = corners[currentCornerIndex];

        // 计算移动方向
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        lastMoveDirection = direction;

        // 移动敌人
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 检查是否到达目标角点
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            // 更新当前目标角点索引
            currentCornerIndex = (currentCornerIndex + 1) % corners.Length;
            UpdateFacingDirection();
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

