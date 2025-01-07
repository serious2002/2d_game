using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    public float moveSpeed = 5f; // �����ƶ��ٶ�
    public Vector2 rectSize = new Vector2(10, 5); // ���εĴ�С, xΪ���, yΪ�߶�
    private Vector2[] corners; // ���ε��ĸ��ǵ�
    private int currentCornerIndex = 0; // ��ǰĿ��ǵ������
    private SpriteRenderer spriteRenderer; // SpriteRenderer���

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // ��ȡSpriteRenderer���
        // ������ε��ĸ��ǵ�
        Vector2 center = transform.position; // ��������Ϊ���˳�ʼλ��
        corners = new Vector2[]
        {
            center + new Vector2(rectSize.x / 2, rectSize.y / 2), // ���Ͻ�
            center + new Vector2(-rectSize.x / 2, rectSize.y / 2), // ���Ͻ�
            center + new Vector2(-rectSize.x / 2, -rectSize.y / 2), // ���½�
            center + new Vector2(rectSize.x / 2, -rectSize.y / 2) // ���½�
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
        // ����Ŀ��ǵ���½�ɫ�ĳ���
        if (transform.position.x < corners[currentCornerIndex].x)
        {
            spriteRenderer.flipX = false; // �����ƶ�ʱͷ������
        }
        else
        {
            spriteRenderer.flipX = true; // �����ƶ�ʱͷ������
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
