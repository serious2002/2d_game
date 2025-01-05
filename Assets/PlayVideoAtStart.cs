using UnityEngine;
using UnityEngine.Video;

public class PlayVideoAtStart : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Play();
    }
}
