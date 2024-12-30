using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskControl : MonoBehaviour
{
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
}
