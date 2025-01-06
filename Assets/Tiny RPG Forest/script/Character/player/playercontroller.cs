using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public float playerdamage=20;
    public float bulletspeed=10;
    public float moveSpeed=5;
    private Rigidbody2D rb;
    Animator animator;
    public InputActions inputActions;
    public Vector2 inputDirection;
    public Vector2 shootDirection;
    Vector2 moveDirection;
    private SpriteRenderer sr;
    private bool isAttacking = false;
    [Header("射击间隔时间")]
    public float shootInterval = 0.5f;  // 发射子弹的间隔，单位秒
    public bool isMeleeAttack = false;
    private float lastShootTime = 0f;  // 记录上次发射子弹的时间

    public void PlayerHurt()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = inputDirection * moveSpeed;


        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", inputDirection.sqrMagnitude);

        if (gameObject.name == "Player1")
        {
            if (moveX < 0)
            {
                sr.flipX = true; // 向左反转
            }
            else if (moveX > 0)
            {
                sr.flipX = false; // 恢复默认方向
            }
        }


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
        if (Input.GetKeyDown(KeyCode.C) && !isMeleeAttack)
        {
            TriggerAttack();
        }
    }



    private void TriggerAttack()
    {
        isMeleeAttack = true; // 设置为近战攻击状态
        animator.SetBool("isMeleeAttack", true); // 设置 Animator 参数

        Debug.Log("触发近战攻击！");

        // 等待攻击动画完成后重置状态
        StartCoroutine(ResetAttackState());
    }

    private IEnumerator ResetAttackState()
    {
        // 假设攻击动画持续 0.5 秒，等待时间与动画时长一致
        yield return new WaitForSeconds(0.5f);

        isMeleeAttack = false; // 重置近战攻击状态
        animator.SetBool("isMeleeAttack", false); // 重置 Animator 参数

        Debug.Log("近战攻击结束！");
    }





    private void Awake()
    {
        inputActions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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

