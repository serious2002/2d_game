using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHintManager : MonoBehaviour
{
    [Header("UI���")]
    public GameObject gameplayHint; // �淨��ʾ���ı�

    [Header("��ʾ����")]
    public string hintText = "�ٿ����ǻ�ɱ�����õ�Կ�ף��ڹ涨ʱ���ڽ��ϱ����͵��յ�";

    private void Start()
    {
        if (gameplayHint != null)
        {
            gameplayHint.SetActive(false); // ��ʼ������ʾ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ȷ������Ҵ���
        {
            ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ����뿪ʱ������ʾ
        {
            HideHint();
        }
    }

    private void ShowHint()
    {
        if (gameplayHint != null)
        {
            gameplayHint.SetActive(true);
            Text hintTextComponent = gameplayHint.GetComponent<Text>();
            if (hintTextComponent != null)
            {
                hintTextComponent.text = hintText; // ������ʾ����
            }
        }
    }

    private void HideHint()
    {
        if (gameplayHint != null)
        {
            gameplayHint.SetActive(false);
        }
    }
}
