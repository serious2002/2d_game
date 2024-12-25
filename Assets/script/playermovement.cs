using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ��ȡ�������
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Ӧ���ƶ�
        rb.velocity = moveDirection * moveSpeed;
    }
}

