/*
 * �ļ�˵������ʾ�Ի���
 * ���ļ�������npc��
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox; //�Ի���
    //npc���֣���ɾ��ֻ����д��
    public Text nameText;
    public string npcName;
    //

    // Update is called once per frame
    private void Update()
    {
        //��E�Ի����ɸ��ģ�
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
