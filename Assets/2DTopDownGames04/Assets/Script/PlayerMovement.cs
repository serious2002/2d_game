using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    Animator animator;

    // Start is called before the first frame update

    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log("Update"+Time.deltaTime);
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate" + Time.deltaTime);
        //��ȡ�������
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Debug.Log("moveX:" + moveX + ",moveY:" + moveY);

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        //�����ƶ�����
        moveDirection = new Vector2(moveX, moveY).normalized;

        //Ӧ���ƶ�
        rb.velocity = moveDirection * moveSpeed;
    }
}