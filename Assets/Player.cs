using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    // 单例模式
    public static Player Instance { get; private set; }

    [Header("获取玩家输入")]
    public PlayerInput input;

    [Header("近战攻击")]
    public float meleeAttackDamage;

    public Vector2 attackSize = new Vector2(1f, 1f); // 攻击范围的尺寸
    public float offsetX = 0.76f; // X轴的偏移量
    public float offsetY = 0.26f; // Y轴的偏移量
    private Vector2 AttackAreaPos;
    private SpriteRenderer spriteRenderer;
    public LayerMask enemyLayer;

    [Header("实时扣血设置")]
    public bool isAutoReduceHealth = false; // 是否实时扣血
    public float healthReductionSpeed = 1f; // 扣血速度（每秒扣血量）
    private float timeSinceLastReduction = 0f; // 距离上次扣血的时间

    [Header("UI设置")]
    public GUIStyle healthStyle; // 血量显示样式
    public GUIStyle taskFailedStyle; // 任务失败样式

    private bool isTaskFailed = false; // 任务失败标记

    private void Awake()
    {
        Instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
        input.EnableGameplayeInput();

        // 初始化样式
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
        // 自动扣血逻辑
        if (isAutoReduceHealth)
        {
            timeSinceLastReduction += Time.deltaTime;
            if (timeSinceLastReduction >= 1f) // 每秒扣血一次
            {
                TakeDamage(healthReductionSpeed);
                timeSinceLastReduction = 0f;
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        // 检查血量是否小于等于 0
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
        base.RestoreHealth(amount); // 调用父类逻辑
    }

    void MeleeAttackAnimEvent()
    {
        // 中心偏移量
        AttackAreaPos = transform.position;

        // 是否翻转
        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, enemyLayer);

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
        // 玩家移动逻辑
    }

    private void OnGUI()
    {
        // 显示血量
        GUI.Label(new Rect(200, 20, 300, 50), $"血量：{currentHealth}/{maxHealth}", healthStyle);


        

    }
}
