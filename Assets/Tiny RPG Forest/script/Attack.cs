using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackEffectPrefab; // ������Ч��Ԥ����
    public Transform attackSpawnPoint;   // ������Ч���ɵ�λ��

    private void Update()
    {
        // ���¹���������������������
        if (Input.GetMouseButtonDown(0))
        {
            TriggerAttackEffect(); // ����������Ч
        }
    }

    private void TriggerAttackEffect()
    {
        // ���ָ�������ɵ㣬���ڸõ����ɹ�����Ч
        if (attackEffectPrefab != null && attackSpawnPoint != null)
        {
            Instantiate(attackEffectPrefab, attackSpawnPoint.position, attackSpawnPoint.rotation);
            Debug.Log("������Ч�����ɣ�");
        }
        else
        {
            Debug.LogWarning("δ���ù�����Ч�����ɵ㣡");
        }
    }
}