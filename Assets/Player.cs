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
        Debug.Log(moveInput);
    }

}
