using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool isVideoCompleted = false; // 用于确保场景只加载一次

    void Start()
    {
        // 获取VideoPlayer组件的引用
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        // 如果视频已经完成，就不再检查
        if (isVideoCompleted)
        {
            return;
        }

        // 检查VideoPlayer的isPlaying属性
        if (!videoPlayer.isPlaying)
        {
            // 视频播放完成，加载下一个场景
            LoadNextScene();
            isVideoCompleted = true; // 设置标志以防止重复加载
        }
    }

    private void LoadNextScene()
    {
        // 假设下一个场景的名称是"NextScene"
        string nextSceneName = "scene_test1";
        SceneManager.LoadScene(nextSceneName);
    }
}

