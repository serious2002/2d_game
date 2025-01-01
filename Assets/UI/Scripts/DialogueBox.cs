/*
 * 文件说明：显示对话框
 * 该文件搭载在npc上
 * 使用时，将对话框拖入dialogueBox，将player的Tag（在Inspector中）改为Player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox; //对话框
    private bool playerNpc; //判断是否靠近npc
    //npc名字，可删，只是先写着
    public Text nameText;
    public string npcName;
    //

    // Update is called once per frame
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNpc = true;
            Debug.Log("1");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNpc = false;
            dialogueBox.SetActive(false);
            Debug.Log("2");
        }
    }
    void Update()
    {
        //按E对话（可更改）
        if(playerNpc == true && Input.GetKeyDown(KeyCode.E))
        {
            //
            nameText.text = npcName;
            //
            dialogueBox.SetActive(true);
        }
    }
}
