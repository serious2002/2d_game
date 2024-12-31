using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public GameObject enemy;
    public InputActions inputActions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获取鼠标在屏幕上的位置
        Vector3 mousePosition = Input.mousePosition;
        // 将屏幕坐标转换为世界坐标
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // 更新准心的位置
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("1");
            Enemy enemy= collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("2");
                enemy.TakeDamage(100);
            }
        }
    }
}
