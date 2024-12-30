using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{


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
