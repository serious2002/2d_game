using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Lifebar Lifebar;  //����LifebarѪ���ű�

    public int maxLife = 5;  //�������ֵ

    public int currentLife; //��ǰ����ֵ

    void Start()
    {
        currentLife = maxLife;
    }


    //�����䣬�ܵ��˺�������������playDamaged������ʵ�ּ�������ֵ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            playerDamaged(1);
        }
    }



    //����ɫ�ܵ��˺����ɸ���ʵ������޸Ĳ���
    private void playerDamaged(int damage)
    {
        currentLife -= damage;
        Lifebar.setLifebar(currentLife);//��ÿ������ʱ����������ֵ
    }
}
