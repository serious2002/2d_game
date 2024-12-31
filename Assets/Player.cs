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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)")
        {
            bullet bullet = collision.gameObject.GetComponent<bullet>();
            if (bullet.is_enemy)
            {
                if (bullet != null)
                {
                    // 读取子弹的 Damage 属性并计算伤害
                    TakeDamage(bullet.damage);

                    // 销毁子弹
                    Destroy(collision.gameObject);

                    // 输出当前生命值
                    Debug.Log(currentHealth);
                }
            }
        }
    }

}
