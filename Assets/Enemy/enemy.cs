using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy : Character
{ 
    public UnityEvent<Vector2> OnMovementInput;

    public UnityEvent OnAttack;

    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 3f; //׷������
    [SerializeField] private float attackDistance = 0.8f; //��������

    private void Update()
    {
        if (player = null)
            return;
        float distance = Vector2.Distance(player.position, transform.position);

        if(distance <= chaseDistance)//�ж�����ҵľ����Ƿ�С�ڵ���׷����Χ
        {
            if(distance <= attackDistance)//�ж�����ҵľ����Ƿ�С�ڵ��ڹ�����Χ
            {
                //�������
      
                OnMovementInput?.Invoke(Vector2.zero);//ֹͣ�ƶ�

                OnAttack?.Invoke();
            }
            else
            {
                // ׷�����
                Vector2 direction = player.position - transform.position;
                OnMovementInput?.Invoke(direction.normalized); // ���ƶ����򴫸�EnemyController

            }

        }
        else
        {
            //�������׷����Χ������׷��
            // ����׷��
            OnMovementInput?.Invoke(Vector2.zero);

        }

    }
   

}
