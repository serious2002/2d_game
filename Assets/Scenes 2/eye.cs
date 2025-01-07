using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject player;
    private float originalRotation; //     ԭʼ Ƕ 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalRotation = transform.rotation.eulerAngles.z; //   ȡ  ʼ  ת Ƕ 
    }

    //    ݵ    ƶ          Ұ    ת ;   ת
    public void UpdateDirection(Vector2 moveDirection)
    {
        //       ˵ĳ   
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        //     Ұ  eye      ת    Ϊ     ƶ  ķ   
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + originalRotation));

        //      ƶ    򽻻  xy λ  
        if (moveDirection.x > 0.1)  //     
        {
            //      ƶ ʱ      ԭ е λ  
            transform.localPosition = new Vector3(3, 0, 0);
            sr.flipY = false;  //     ʱ      Ҫ Y   ת
        }
        else if (moveDirection.x < -0.1)  //     
        {
            //      ƶ ʱ       x    y     
            transform.localPosition = new Vector3(-3, 0, 0);
            sr.flipY = false;  //     ʱ      Ҫ Y   ת
        }

        //      ƶ         ת Y  ᣨ  ֱ  
        if (moveDirection.y > 0.1)  //     
        {
            //      ƶ ʱ       x    y     
            transform.localPosition = new Vector3(0, 3, 0);
            sr.flipY = false;  //     ʱ      Ҫ Y   ת
        }
        else if (moveDirection.y < -0.1)  //     
        {
            //      ƶ ʱ       x    y     
            transform.localPosition = new Vector3(0, -3, 0);
            sr.flipY = false;  //     ʱ    Ҫ Y   ת
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player1")
        {
            player.TryGetComponent<Player>(out var playerScript);
            if (playerScript != null)
            {
                playerScript.TakeDamage(100);
            }
        }
    }
}
