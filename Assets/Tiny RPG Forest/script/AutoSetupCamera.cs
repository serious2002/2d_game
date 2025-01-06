 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
//摄像机一运行就自动跟随玩家


public class AutoSetupCamera : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        CinemachineVirtualCamera camera = GetComponent<CinemachineVirtualCamera>();

        player = FindObjectOfType<Player>();//在场景中查找Player类型的对象实例

        if(player!= null )
        {
            camera.Follow = player.transform;
        }
    }
}
