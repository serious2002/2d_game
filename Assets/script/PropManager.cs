using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public int coinCount;
    public int equipmentCount;
    public int keyCount;
    public int potionCount;

    [Header("玩家组件")]
    public Player player; // 玩家脚本，用于加血操作
    public float potionHealAmount = 20f; // 药瓶恢复的血量

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case Constants.TAG_COIN:

                PickUpCoin();
                return true;
            case Constants.TAG_EQUIPMENT:
                PickUpEquipment();
                return true;
            case Constants.TAG_KEY:
                PickUpKey();
                return true;
            case Constants.TAG_POTION:
                PickUpPotion();
                return true;
            case Constants.TAG_MAP:
                PickUpMap();
                return true;
            default:
                Debug.Log("不可拾取");
                return false;
        }
    }
    private void OnGUI()
    {
        GUI.contentColor = Color.black; // 设置字体颜色为黑色
        GUI.skin.label.fontSize = 30; // 设置字体大小为30

        GUI.Label(new Rect(20, 20, 300, 40), "Coin Num: " + coinCount);
        GUI.Label(new Rect(20, 70, 300, 40), "Equipment Num: " + equipmentCount);
        GUI.Label(new Rect(20, 120, 300, 40), "Key Num: " + (keyCount-1));
        GUI.Label(new Rect(20, 170, 300, 40), "Potion Num: " + potionCount);

    }

    private void PickUpCoin()
    {
        coinCount++;
    }

    private void PickUpEquipment()
    {
        equipmentCount++;
    }

    private void PickUpKey()
    {
        keyCount++;
    }

    private void PickUpPotion()
    {
         potionCount++;
        if (player != null)
        {
            player.RestoreHealth(potionHealAmount);
            Debug.Log($"使用药瓶恢复血量：{potionHealAmount}，当前血量：{player.currentHealth}/{player.maxHealth}");
        }
        else
        {
            Debug.LogWarning("未绑定玩家脚本，无法恢复血量！");
        }
    }

    private void PickUpMap()
    {
        
    }

}


