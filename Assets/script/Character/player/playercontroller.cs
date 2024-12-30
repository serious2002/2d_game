using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public float playerdamage=20;
    public float bulletspeed=10;
    public float moveSpeed;
    private Rigidbody2D rb;
    public InputActions inputActions;
    public Vector2 inputDirection;
    public Vector2 shootDirection;

    [Header("射击间隔时间")]
    public float shootInterval = 0.5f;  // 发射子弹的间隔，单位秒

    private float lastShootTime = 0f;  // 记录上次发射子弹的时间

    public void PlayerHurt()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = inputDirection * moveSpeed;

        if (shootDirection != new Vector2(0.00f, 0.00f) && Time.time >= lastShootTime + shootInterval)
        {
            lastShootTime = Time.time;
            
            GameObject newBullet = GameObject.Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody= newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = shootDirection * bulletspeed;

            // 获取子弹的 Bullet 脚本组件并修改伤害值
            if (newBullet.TryGetComponent<bullet>(out var bulletScript))
            {
                bulletScript.damage = playerdamage;  // 修改子弹的伤害值
            }
        }
    }
    

    void Update()
    {
        inputDirection = inputActions.GamePlay.Move.ReadValue<Vector2>();
        shootDirection = inputActions.GamePlay.Shoot.ReadValue<Vector2>();
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

