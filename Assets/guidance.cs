using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHintManager : MonoBehaviour
{
    [Header("UI组件")]
    public GameObject gameplayHint; // 玩法提示的文本

    [Header("提示内容")]
    public string hintText = "操控主角击杀敌人拿到钥匙，在规定时间内将老兵护送到终点";

    private void Start()
    {
        if (gameplayHint != null)
        {
            gameplayHint.SetActive(false); // 初始隐藏提示
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 确保是玩家触发
        {
            ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 玩家离开时隐藏提示
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
                hintTextComponent.text = hintText; // 设置提示内容
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
