/*
 * �ļ�˵����ͨ����ȡ�Ի��ļ�����ʾ��ζԻ�
 * ���ļ������ڶԻ�����
 * �Ի��ļ�Ϊtxt��ע��ֶΣ�����ʱע����뷽ʽΪUTF-8
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI���")]
    public Text textLabel;

    [Header("�ı��ļ�")]
    public TextAsset textFile;
    public int index;
    public float textSpeed; //������ʾ�ٶ�
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
        //���жԻ�����
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
        //���ζԻ�����
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
