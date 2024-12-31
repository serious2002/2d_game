using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //单例模式
    public static Player Instance {  get; private set; }


    [Header("获取玩家输入")]
    public PlayerInput input;

    [Header("近战攻击")]
    public float meleeAttackDamage;

    public Vector2 attackSize = new Vector2(1f, 1f); // 攻击范围的尺寸
    public float offsetX = 0.76f; // X轴的偏移量
    public float offsetY = 0.26f; // Y轴的偏移量
    private Vector2 AttackAreaPos;
    private SpriteRenderer SpriteRenderer;
    public LayerMask enemyLayer;

    void MeleeAttackAnimEvent()
    {
        // 中心偏移量
        AttackAreaPos = transform.position;

        // 是否翻转
        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f,enemyLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>()?.TakeDamage(meleeAttackDamage * 1);
        }
    }


    // 绘图用于测试
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(AttackAreaPos, attackSize);
    }



[Header("远程攻击")]


    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
        input.EnableGameplayeInput();
    }

    protected override void OnEnable()
    {
        input.onMove += Move;
        base.OnEnable();
    }

    private void OnDisable()
    {
        input.onMove -= Move;
    }

    public void Move(Vector2 moveInput)
    {
        
    }

}
