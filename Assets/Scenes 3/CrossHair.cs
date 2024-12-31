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
        // ��ȡ�������Ļ�ϵ�λ��
        Vector3 mousePosition = Input.mousePosition;
        // ����Ļ����ת��Ϊ��������
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // ����׼�ĵ�λ��
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
