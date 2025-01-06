using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isVideoCompleted = false; // ����ȷ������ֻ����һ��

    void Start()
    {
        // ��ȡVideoPlayer���������
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        // �����Ƶ�Ѿ���ɣ��Ͳ��ټ��
        if (isVideoCompleted)
        {
            return;
        }

        // ���VideoPlayer��isPlaying����
        if (!videoPlayer.isPlaying)
        {
            // ��Ƶ������ɣ�������һ������
            LoadNextScene();
            isVideoCompleted = true; // ���ñ�־�Է�ֹ�ظ�����
        }
    }

    private void LoadNextScene()
    {
        // ������һ��������������"NextScene"
        string nextSceneName = "scene_test1";
        SceneManager.LoadScene(nextSceneName);
    }
}

