/*
 * 文件说明：显示对话框
 * 该文件搭载在npc上
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox; //对话框
    //npc名字，可删，只是先写着
    public Text nameText;
    public string npcName;
    //

    // Update is called once per frame
    private void Update()
    {
        //按E对话（可更改）
        if(Input.GetKeyDown(KeyCode.E))
        {
            //
            //nameText.text = npcName;
            //
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueBox.SetActive(false);
    }
}
