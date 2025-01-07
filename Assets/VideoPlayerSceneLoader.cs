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

        // ��ת��ָ���ĳ���
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);



    }

    private void SkipVideo()
    {
        Debug.Log("������Ƶ��");
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }

    private void Update()
    {
        // ������ⰴ��������Ƶ
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SkipVideo();
        }
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
