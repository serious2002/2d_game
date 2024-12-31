using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Character
{
    public static Enemy Instance { get; private set; }

    public GameObject Bullet;
    private Vector2 shootDirection;
    public float enemydamage=20;
    public float bulletspeed = 10;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        EnemyManager.Instance.enemyCount++;
    }
    private void OnDestroy()
    {
        EnemyManager.Instance.enemyCount--;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)")
        {
            bullet bullet = collision.gameObject.GetComponent<bullet>();

            if (bullet != null)
            {
                // ��ȡ�ӵ��� Damage ���Բ������˺�
                TakeDamage(bullet.damage);

                // �����ӵ�
                Destroy(collision.gameObject);

                // �����ǰ����ֵ
                Debug.Log(currentHealth);
            }
        }
    }

    private void Shooting()
    {
        GameObject newBullet = GameObject.Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootDirection * bulletspeed;

        // ��ȡ�ӵ��� Bullet �ű�������޸��˺�ֵ
        if (newBullet.TryGetComponent<bullet>(out var bulletScript))
        {
            bulletScript.damage = enemydamage;  // �޸��ӵ����˺�ֵ
        }
    }
}
