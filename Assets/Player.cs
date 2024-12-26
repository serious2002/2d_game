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
        Debug.Log(moveInput);
    }

}
