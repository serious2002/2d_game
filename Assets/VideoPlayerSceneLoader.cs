using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ�������
    public string targetSceneName;  // Ҫ��ת����Ŀ�곡������

    private void Start()
    {
        // ע����Ƶ���Ž����¼�
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        Debug.Log("��Ƶ������ϣ�������ת������");
        // ��Ƶ���Ž�����ֹͣ��Ƶ����
        videoPlayer.Stop();
        // ��ת��ָ���ĳ���
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }

    private void OnDestroy()
    {
        // �ڶ�������ʱȡ��ע���¼�����ֹ�ڴ�й©
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
