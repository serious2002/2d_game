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
    [Header("������ʱ��")]
    public float shootInterval = 0.5f;  // �����ӵ��ļ������λ��
    public bool isMeleeAttack = false;
    private float lastShootTime = 0f;  // ��¼�ϴη����ӵ���ʱ��

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
                sr.flipX = true; // ����ת
            }
            else if (moveX > 0)
            {
                sr.flipX = false; // �ָ�Ĭ�Ϸ���
            }
        }


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
        if (Input.GetKeyDown(KeyCode.C) && !isMeleeAttack)
        {
            TriggerAttack();
        }
    }



    private void TriggerAttack()
    {
        isMeleeAttack = true; // ����Ϊ��ս����״̬
        animator.SetBool("isMeleeAttack", true); // ���� Animator ����

        Debug.Log("������ս������");

        // �ȴ�����������ɺ�����״̬
        StartCoroutine(ResetAttackState());
    }

    private IEnumerator ResetAttackState()
    {
        // ���蹥���������� 0.5 �룬�ȴ�ʱ���붯��ʱ��һ��
        yield return new WaitForSeconds(0.5f);

        isMeleeAttack = false; // ���ý�ս����״̬
        animator.SetBool("isMeleeAttack", false); // ���� Animator ����

        Debug.Log("��ս����������");
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

