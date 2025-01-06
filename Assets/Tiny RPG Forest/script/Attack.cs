using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackEffectPrefab; // 攻击特效的预制体
    public Transform attackSpawnPoint;   // 攻击特效生成的位置

    private void Update()
    {
        // 按下攻击键（假设是鼠标左键）
        if (Input.GetMouseButtonDown(0))
        {
            TriggerAttackEffect(); // 触发攻击特效
        }
    }

    private void TriggerAttackEffect()
    {
        // 如果指定了生成点，则在该点生成攻击特效
        if (attackEffectPrefab != null && attackSpawnPoint != null)
        {
            Instantiate(attackEffectPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
            Debug.Log("攻击特效已生成！");
        }
        else
        {
            Debug.LogWarning("未设置攻击特效或生成点！");
        }
    }
}