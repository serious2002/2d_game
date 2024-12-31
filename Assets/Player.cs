using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //����ģʽ
    public static Player Instance {  get; private set; }


    [Header("��ȡ�������")]
    public PlayerInput input;

    [Header("��ս����")]
    public float meleeAttackDamage;

    public Vector2 attackSize = new Vector2(1f, 1f); // ������Χ�ĳߴ�
    public float offsetX = 0.76f; // X���ƫ����
    public float offsetY = 0.26f; // Y���ƫ����
    private Vector2 AttackAreaPos;
    private SpriteRenderer SpriteRenderer;
    public LayerMask enemyLayer;

    void MeleeAttackAnimEvent()
    {
        // ����ƫ����
        AttackAreaPos = transform.position;

        // �Ƿ�ת
        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f,enemyLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>()?.TakeDamage(meleeAttackDamage * 1);
        }
    }


    // ��ͼ���ڲ���
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(AttackAreaPos, attackSize);
    }



[Header("Զ�̹���")]


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
