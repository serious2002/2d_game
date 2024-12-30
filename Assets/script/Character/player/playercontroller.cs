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

    [Header("������ʱ��")]
    public float shootInterval = 0.5f;  // �����ӵ��ļ������λ��

    private float lastShootTime = 0f;  // ��¼�ϴη����ӵ���ʱ��

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

            // ��ȡ�ӵ��� Bullet �ű�������޸��˺�ֵ
            if (newBullet.TryGetComponent<bullet>(out var bulletScript))
            {
                bulletScript.damage = playerdamage;  // �޸��ӵ����˺�ֵ
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

