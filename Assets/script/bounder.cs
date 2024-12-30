using Cinemachine;//ʹ�ÿ�
using UnityEngine;

public class SwitchBounds : MonoBehaviour
{
    private void Start()
    {
        SwitchConfinerShape();
    }

    private void SwitchConfinerShape()
    {
        //Ѱ��bounds����ȡ�����ϵ����
        PolygonCollider2D confinerShape = GameObject.FindGameObjectWithTag("Bounds").GetComponent<PolygonCollider2D>();
        //��ȡ�������
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        //��ֵ
        confiner.m_BoundingShape2D = confinerShape;

        confiner.InvalidatePathCache();
    }
}

