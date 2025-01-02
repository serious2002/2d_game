using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Lifebar Lifebar;  //引入Lifebar血条脚本

    public int maxLife = 5;  //最大生命值

    public int currentLife; //当前生命值

    void Start()
    {
        currentLife = maxLife;
    }


    //待补充，受到伤害的条件并调用playDamaged（）以实现减少生命值
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            playerDamaged(1);
        }
    }



    //当角色受到伤害，可根据实际情况修改补充
    private void playerDamaged(int damage)
    {
        currentLife -= damage;
        Lifebar.setLifebar(currentLife);//在每次受伤时，更新生命值
    }
}
