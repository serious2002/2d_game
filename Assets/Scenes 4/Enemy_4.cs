using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制移动速度
    public Vector2 rectSize = new Vector2(10, 5); // 矩形的大小, x为宽度, y为高度
    private Vector2[] corners; // 矩形的四个角点
    private int currentCornerIndex = 0; // 当前目标角点的索引
    private SpriteRenderer spriteRenderer; // SpriteRenderer组件

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 获取SpriteRenderer组件
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
        Move();
    }

    private void Move()
    {
        Vector2 targetPosition = corners[currentCornerIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentCornerIndex = (currentCornerIndex + 1) % corners.Length;
            UpdateFacingDirection();
        }
    }

    private void UpdateFacingDirection()
    {
        // 根据目标角点更新角色的朝向
        if (transform.position.x < corners[currentCornerIndex].x)
        {
            spriteRenderer.flipX = false; // 向左移动时头部向左
        }
        else
        {
            spriteRenderer.flipX = true; // 向右移动时头部向右
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
