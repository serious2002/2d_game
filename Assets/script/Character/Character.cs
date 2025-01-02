using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject keyPrefab;
    [Header("����")]
    [SerializeField] protected float maxHealth=100;


    [SerializeField] protected float currentHealth=100;

    protected virtual void OnEnable()
    {
        currentHealth=maxHealth;
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
            // ��������˵���㣬���ڵ��������Կ�ף������ڵ��˵�ǰλ������
            Vector3 dropPosition = transform.position;
            Instantiate(keyPrefab, dropPosition, Quaternion.identity);
            Debug.Log("Կ���ѵ��䣡");
        }
    }

}
