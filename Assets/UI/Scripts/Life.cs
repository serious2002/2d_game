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
    


    //����ɫ�ܵ��˺����ɸ���ʵ������޸Ĳ���
    //private void playerDamaged(int damage)
    //{
    //    currentLife -= damage;
    //    Lifebar.setLifebar(currentLife);//��ÿ������ʱ����������ֵ
    //}
}
