using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    // ����ģʽ
    public static Player Instance { get; private set; }

    [Header("��ȡ�������")]
    public PlayerInput input;

    [Header("��ս����")]
    public float meleeAttackDamage;

    public Vector2 attackSize = new Vector2(1f, 1f); // ������Χ�ĳߴ�
    public float offsetX = 0.76f; // X���ƫ����
    public float offsetY = 0.26f; // Y���ƫ����
    private Vector2 AttackAreaPos;
    private SpriteRenderer spriteRenderer;
    public LayerMask enemyLayer;

    [Header("ʵʱ��Ѫ����")]
    public bool isAutoReduceHealth = false; // �Ƿ�ʵʱ��Ѫ
    public float healthReductionSpeed = 1f; // ��Ѫ�ٶȣ�ÿ���Ѫ����
    private float timeSinceLastReduction = 0f; // �����ϴο�Ѫ��ʱ��

    [Header("UI����")]
    public GUIStyle healthStyle; // Ѫ����ʾ��ʽ
    public GUIStyle taskFailedStyle; // ����ʧ����ʽ

    private bool isTaskFailed = false; // ����ʧ�ܱ��

    private void Awake()
    {
        Instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
        input.EnableGameplayeInput();

        // ��ʼ����ʽ
        healthStyle = new GUIStyle();
        healthStyle.fontSize = 30;
        healthStyle.normal.textColor = Color.black;

        taskFailedStyle = new GUIStyle();
        taskFailedStyle.fontSize = 50;
        taskFailedStyle.alignment = TextAnchor.MiddleCenter;
        taskFailedStyle.normal.textColor = Color.red;
    }

    private void Update()
    {
        // �Զ���Ѫ�߼�
        if (isAutoReduceHealth)
        {
            timeSinceLastReduction += Time.deltaTime;
            if (timeSinceLastReduction >= 1f) // ÿ���Ѫһ��
            {
                TakeDamage(healthReductionSpeed);
                timeSinceLastReduction = 0f;
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        // ���Ѫ���Ƿ�С�ڵ��� 0
        if (currentHealth <= 0 && !isTaskFailed)
        {
            TaskFailed();
        }
    }

    private void TaskFailed()
    {
        isTaskFailed = true;
    }

    public override void RestoreHealth(float amount)
    {
        base.RestoreHealth(amount); // ���ø����߼�
    }

    void MeleeAttackAnimEvent()
    {
        // ����ƫ����
        AttackAreaPos = transform.position;

        // �Ƿ�ת
        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, enemyLayer);

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
        // ����ƶ��߼�
    }

    private void OnGUI()
    {
        // ��ʾѪ��
        GUI.Label(new Rect(200, 20, 300, 50), $"Ѫ����{currentHealth}/{maxHealth}", healthStyle);


        

    }
}
