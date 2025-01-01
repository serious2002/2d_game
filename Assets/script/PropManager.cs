using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public int coinCount;
    public int equipmentCount;
    public int keyCount;
    public int potionCount;

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
    }


}


