using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float moveSpeed = 5f; //      ƶ  ٶ 
    public Vector2 rectSize = new Vector2(10, 5); //    εĴ С  x Ϊ   ȣ y Ϊ ߶ 
    private SpriteRenderer spriteRenderer;
    private Vector2[] corners; //    ε  ĸ  ǵ 
    private int currentCornerIndex = 0; //   ǰĿ  ǵ      

    private Vector2 lastMoveDirection = Vector2.zero; //   ¼  һ ε  ƶ     

    private eye enemyEye; //    ڿ     Ұ  ת

    private void Start()
    {
        //   ȡ eye           eye    Enemy_2    Ӷ   
        enemyEye = GetComponentInChildren<eye>();

        //       ε  ĸ  ǵ 
        Vector2 center = transform.position; //         Ϊ   ˳ ʼλ  
        corners = new Vector2[]
        {
            center + new Vector2(rectSize.x / 2, rectSize.y / 2), //    Ͻ 
            center + new Vector2(-rectSize.x / 2, rectSize.y / 2), //    Ͻ 
            center + new Vector2(-rectSize.x / 2, -rectSize.y / 2), //    ½ 
            center + new Vector2(rectSize.x / 2, -rectSize.y / 2) //    ½ 
        };
    }

    private void UpdateFacingDirection()
    {
        // 根据目标角点更新角色的朝向
        if (transform.position.x < corners[currentCornerIndex].x)
        {
            spriteRenderer.flipX = false; // 向左移动时头部向左
        }
        else
        {
            spriteRenderer.flipX = true; // 向右移动时头部向右
        }
    }



    private void Update()
    {
        //      Move     ʹ     ƾ    ƶ 
        Move();

        //       Ұ  eye       ƶ     ת
        if (enemyEye != null)
        {
            enemyEye.UpdateDirection(lastMoveDirection);
        }
    }

    private void Move()
    {
        //   ȡ  ǰĿ  ǵ 
        Vector2 targetPosition = corners[currentCornerIndex];

        //   ¼     ƶ  ķ   
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        lastMoveDirection = direction;

        // ʹ   Vector2.MoveTowards     ʹ      Ŀ  ǵ  ƶ    ƶ  ٶ Ϊ moveSpeed
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);



        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            //      ˵   Ŀ  ǵ ʱ      Ŀ  ǵ        ʹ  ָ    һ   ǵ 
            currentCornerIndex = (currentCornerIndex + 1) % corners.Length;
            //if (direction.x > 0) // 向右移动
            //{
            //    spriteRenderer.flipX = false; // 朝右
            //}
            //else if (direction.x < 0) // 向左移动
            //{
            //    spriteRenderer.flipX = true; // 朝左
            //}


        }
    }

    private void OnDestroy()
    {
        if (EnemyManager_4.Instance != null)
        {
            EnemyManager_4.Instance.DecreaseEnemyCount();
        }
    }
}
