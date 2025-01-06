using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_4 : MonoBehaviour
{
    public float moveSpeed = 5f; // �����ƶ��ٶ�
    public Vector2 rectSize = new Vector2(10, 5); // ���εĴ�С��x Ϊ��ȣ�y Ϊ�߶�

    private Vector2[] corners; // ���ε��ĸ��ǵ�
    private int currentCornerIndex = 0; // ��ǰĿ��ǵ������

    private void Start()
    {
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
        // ���� Move ����ʹ�����ƾ����ƶ�
        Move();
    }

    private void Move()
    {
        // ��ȡ��ǰĿ��ǵ�
        Vector2 targetPosition = corners[currentCornerIndex];

        // ʹ�� Vector2.MoveTowards ����ʹ������Ŀ��ǵ��ƶ����ƶ��ٶ�Ϊ moveSpeed
        // Time.deltaTime ��Ϊ��ʹ�ƶ��ٶȲ���֡��Ӱ��
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // ������˵�ǰλ����Ŀ��ǵ�ľ���С�� 0.1f������Ϊ�����Ѿ�����Ŀ��ǵ�
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            // �����˵���Ŀ��ǵ�ʱ������Ŀ��ǵ��������ʹ��ָ����һ���ǵ�
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