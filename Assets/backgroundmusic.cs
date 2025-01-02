using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // ���������ļ�
    private AudioSource audioSource;

    private static BackgroundMusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // ��� AudioSource ���������
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.playOnAwake = true;
            audioSource.volume = 0.2f; // �ɵ�������
            audioSource.Play(); // ��ʼ���ű�������
        }
        else
        {
            Destroy(gameObject); // ����Ѿ�����һ���������ֶ��������µ�ʵ��
        }
    }
}
