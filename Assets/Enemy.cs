using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)")
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
            Debug.Log(currentHealth);
        }
    }
}
