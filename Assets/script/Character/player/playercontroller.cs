using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public InputActions inputActions;
    public Vector2 inputDirection;

    public void PlayerHurt()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = inputDirection * moveSpeed;
    }

    void Update()
    {
        inputDirection = inputActions.GamePlay.Move.ReadValue<Vector2>();
    }

    private void Awake()
    {
        inputActions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

}

