using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // 背景音乐文件
    private AudioSource audioSource;

    private static BackgroundMusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 添加 AudioSource 组件并配置
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.playOnAwake = true;
            audioSource.volume = 0.2f; // 可调整音量
            audioSource.Play(); // 开始播放背景音乐
        }
        else
        {
            Destroy(gameObject); // 如果已经存在一个背景音乐对象，销毁新的实例
        }
    }
}
