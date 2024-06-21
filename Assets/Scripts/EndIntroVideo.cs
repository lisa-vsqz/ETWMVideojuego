using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoEndSceneChanger : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public string sceneName = "Forest"; // The name of the scene to load after the video ends

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            // Subscribe to the loopPointReached event
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the specified scene when the video ends
        SceneManager.LoadScene("Forest");
    }
}
