using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class enemy : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;

    public UnityEvent<Vector2> OnAttack;
    
    [SerializeField] private Transform : player
    [SerializeField] private float chaseDistance = 3f; //׷������

    [SerializeField] private float attackDistance = 3f; //��������

    private void Update()
    {
        if (player = null)
            return;
        float distance = Vector2 Distance(Player: position.transfom position);

//        if(distance <= chaseDistance)//�ж�����ҵľ����Ƿ�С�ڵ���׷����Χ
//        {
//            if(distance <= attackDistance)//�ж�����ҵľ����Ƿ�С�ڵ��ڹ�����Χ
//            {
//                //�������
      
//                OnMovementInput?.Invoke(Vector2.zero);//ֹͣ�ƶ�

//                OnAttack?.Invoke();
//            }
//            else
//            {
//                // ׷�����
//                Vector2 direction = player.position - transform.position;
//                OnMovementInput?.Invoke(direction.normalized); // ���ƶ����򴫸�EnemyController

//            }

//        }
//        else
//        {
//            //�������׷����Χ������׷��
//            // ����׷��
//            OnMovementInput?.Invoke(Vector2.zero);

//        }

//    }
   

//}
