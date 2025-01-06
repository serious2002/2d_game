using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer; // 视频播放组件
    public string targetSceneName;  // 要跳转到的目标场景名称

    private void Start()
    {
        // 注册视频播放结束事件
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer source)
    {
        Debug.Log("视频播放完毕，即将跳转场景！");
        // 视频播放结束后，停止视频播放
        videoPlayer.Stop();
        // 跳转到指定的场景
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }

    private void OnDestroy()
    {
        // 在对象销毁时取消注册事件，防止内存泄漏
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
