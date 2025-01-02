using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed; // 移动速度
    public Rigidbody2D rb;
    Animator animator;

    Vector2 moveDirection;

    [Header("控制变量")]
    public bool isControllable = false; // 是否可以被控制

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isControllable)
        {
            // 如果不可控，则直接返回
            return;
        }

        // 获取玩家输入
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 设置动画参数
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        // 计算移动方向
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        if (!isControllable)
        {
            // 如果不可控，则停止移动
            rb.velocity = Vector2.zero;
            return;
        }

        // 应用移动
        rb.velocity = moveDirection * moveSpeed;
    }
}
