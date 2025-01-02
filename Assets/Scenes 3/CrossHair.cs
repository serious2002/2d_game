using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrossHair : MonoBehaviour
{
    public GameObject Bullet;
    public InputActions inputActions;
    private float lastShootTime = 0f;  // 记录上次发射子弹的时间
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

        if(Input.GetButtonDown("Fire1") && Time.time >= lastShootTime + 0.5)
        {
            lastShootTime = Time.time;

            GameObject newBullet = GameObject.Instantiate(Bullet, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();

            // 获取子弹的 Bullet 脚本组件并修改伤害值
            if (newBullet.TryGetComponent<bullet>(out var bulletScript))
            {
                bulletScript.damage = 100;  // 修改子弹的伤害值
            }
        }

    }

}
