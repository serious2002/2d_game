using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControllor : MonoBehaviour
{
    [Header("ÊôÐÔ")]
    [SerializeField] private float currentSpeed = 0;

    public Vector2 MovementInput { get; set; }

    [Header("¹¥»÷")]
    [SerializeField] private bool isAttack = true;
    [SerializeField] private float attackCoolDuration = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        SetAnimation();
    }

    void Move()
    {
        if (MovementInput.magnitude > 0.1f && currentSpeed >= 0)
        {
            rb.velocity = MovementInput * currentSpeed;
            // Íæ¼Ò×óÓÒ·­×ª
            if (MovementInput.x < 0) // ×ó
            {
                sr.flipX = false;
            }
            if (MovementInput.x > 0) // ÓÒ
            {
                sr.flipX = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Attack()
    {
        if (isAttack)
        {
            isAttack = false;
            StartCoroutine(nameof(AttackCoroutine));
        }
    }


    void SetAnimation()
    {
        anim.SetBool("isWalk", MovementInput.magnitude > 0);
    }

    IEnumerator AttackCoroutine()
    {
        anim.SetTrigger("isAttack");
        yield return new WaitForSeconds(attackCoolDuration);
        isAttack = true;
    }


}
