using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // �ƶ��ٶ�
    public Rigidbody2D rb;
    Animator animator;

    Vector2 moveDirection;

    [Header("���Ʊ���")]
    public bool isControllable = false; // �Ƿ���Ա�����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isControllable)
        {
            // ������ɿأ���ֱ�ӷ���
            return;
        }

        // ��ȡ�������
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // ���ö�������
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        // �����ƶ�����
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        if (!isControllable)
        {
            // ������ɿأ���ֹͣ�ƶ�
            rb.velocity = Vector2.zero;
            return;
        }

        // Ӧ���ƶ�
        rb.velocity = moveDirection * moveSpeed;
    }
}
