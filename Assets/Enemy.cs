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
                // 读取子弹的 Damage 属性并计算伤害
                TakeDamage(bullet.damage);

                // 销毁子弹
                Destroy(collision.gameObject);

                // 输出当前生命值
                Debug.Log(currentHealth);
            }
        }
    }
}
