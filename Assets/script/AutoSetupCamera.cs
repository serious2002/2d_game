 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
//�����һ���о��Զ��������


public class AutoSetupCamera : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        CinemachineVirtualCamera camera = GetComponent<CinemachineVirtualCamera>();

        player = FindObjectOfType<Player>();//�ڳ����в���Player���͵Ķ���ʵ��

        if(player!= null )
        {
            camera.Follow = player.transform;
        }
    }
}
