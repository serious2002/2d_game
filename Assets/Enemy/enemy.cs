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
    [SerializeField] private float chaseDistance = 3f; //×·»÷¾àÀë

    [SerializeField] private float attackDistance = 3f; //¹¥»÷¾àÀë

    private void Update()
    {
        if (player = null)
            return;
        float distance = Vector2 Distance(Player: position.transfom position);

//        if(distance <= chaseDistance)//ÅÐ¶ÏÓëÍæ¼ÒµÄ¾àÀëÊÇ·ñÐ¡ÓÚµÈÓÚ×·»÷·¶Î§
//        {
//            if(distance <= attackDistance)//ÅÐ¶ÏÓëÍæ¼ÒµÄ¾àÀëÊÇ·ñÐ¡ÓÚµÈÓÚ¹¥»÷·¶Î§
//            {
//                //¹¥»÷Íæ¼Ò
      
//                OnMovementInput?.Invoke(Vector2.zero);//Í£Ö¹ÒÆ¶¯

//                OnAttack?.Invoke();
//            }
//            else
//            {
//                // ×·»÷Íæ¼Ò
//                Vector2 direction = player.position - transform.position;
//                OnMovementInput?.Invoke(direction.normalized); // °ÑÒÆ¶¯·½Ïò´«¸øEnemyController

//            }

//        }
//        else
//        {
//            //Íæ¼ÒÍÑÀë×·»÷·¶Î§£¬·ÅÆú×·»÷
//            // ·ÅÆú×·»÷
//            OnMovementInput?.Invoke(Vector2.zero);

//        }

//    }
   

//}
