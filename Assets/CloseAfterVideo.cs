using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CloseAfterVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "GameScene";

    void Update()
    {
        if (videoPlayer.time >= videoPlayer.length && !videoPlayer.isPlaying)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        Debug.Log("Loading next scene: " + nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}


