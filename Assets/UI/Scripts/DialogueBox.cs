/*
 * �ļ�˵������ʾ�Ի���
 * ���ļ�������npc��
 * ʹ��ʱ�����Ի�������dialogueBox����player��Tag����Inspector�У���ΪPlayer
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public GameObject dialogueBox; //�Ի���
    private bool playerNpc; //�ж��Ƿ񿿽�npc
    //npc���֣���ɾ��ֻ����д��
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
        //��E�Ի����ɸ��ģ�
        if(playerNpc == true && Input.GetKeyDown(KeyCode.E))
        {
            //
            nameText.text = npcName;
            //
            dialogueBox.SetActive(true);
        }
    }
}
