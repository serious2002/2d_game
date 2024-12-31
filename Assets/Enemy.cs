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
                // 读取子弹的 Damage 属性并计算伤害
                TakeDamage(bullet.damage);

                // 销毁子弹
                Destroy(collision.gameObject);

                // 输出当前生命值
                Debug.Log(currentHealth);
            }
        }
    }

    private void Shooting()
    {
        GameObject newBullet = GameObject.Instantiate(Bullet, transform.position, transform.rotation);
        Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = shootDirection * bulletspeed;

        // 获取子弹的 Bullet 脚本组件并修改伤害值
        if (newBullet.TryGetComponent<bullet>(out var bulletScript))
        {
            bulletScript.damage = enemydamage;  // 修改子弹的伤害值
        }
    }
}
