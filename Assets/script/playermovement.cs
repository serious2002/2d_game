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
        // 获取玩家输入
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // 应用移动
        rb.velocity = moveDirection * moveSpeed;
    }
}

