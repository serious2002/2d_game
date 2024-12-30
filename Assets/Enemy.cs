using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public static Enemy Instance { get; private set; }

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
}
