/*
 * 文件说明：通过读取对话文件，显示多段对话
 * 该文件搭载在对话框上
 * 对话文件为txt，注意分段，导出时注意编码方式为UTF-8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed; //文字显示速度
    public GameObject npc;
    public GameObject player;
    bool textFinished;

    List<string> textList = new List<string>();


    void Awake()
    {
        GetTextFromFlie(textFile);
    }

    private void OnEnable()
    {
        textFinished = false;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        //所有对话结束
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            if (npc != null)
            {
                npc.GetComponent<PlayerMovement>().isControllable = true;
                player.GetComponent<Player>().isAutoReduceHealth = true;
            }
            return;
        }
        //单段对话结束
        if (Input.GetKeyDown(KeyCode.E) && textFinished)
        {
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFlie(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineData = file.text.Split('\n');
        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        for(int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}
