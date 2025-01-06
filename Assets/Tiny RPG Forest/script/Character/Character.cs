using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject keyPrefab;
    [Header("属性")]
    [SerializeField] public float maxHealth=100;


    [SerializeField] public float currentHealth=100;

    protected virtual void OnEnable()
    {
        currentHealth=maxHealth;
    }

    public virtual void RestoreHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // 确保血量不会超过最大值
        }

        Debug.Log($"血量恢复：{amount}，当前血量：{currentHealth}/{maxHealth}");
    }


    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        currentHealth = 0f;
        Destroy(this.gameObject);
        if (gameObject.name == "EnemySence1")
        {
            DropKey();
        }
    }

    private void DropKey()
    {
        if (keyPrefab != null)
        {
            // 如果设置了掉落点，则在掉落点生成钥匙；否则在敌人当前位置生成
            Vector3 dropPosition = transform.position;
            Instantiate(keyPrefab, dropPosition, Quaternion.identity);
            Debug.Log("钥匙已掉落！");
        }
    }

}
