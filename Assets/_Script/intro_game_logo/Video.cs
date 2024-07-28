using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    public VideoPlayer _videoPlayer;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.Prepare();

        _videoPlayer.loopPointReached += _videoPlayer_loopPointReached;

        Invoke("play", 3);
    }

    private void _videoPlayer_loopPointReached(VideoPlayer source) => SceneManager.LoadScene(1);

    private void play() => _videoPlayer.Play();

    void Update() => ToPressButton();

    void ToPressButton() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Escape))
        {
            if (_videoPlayer.isPlaying)
                SceneManager.LoadScene(1);
        }
    }
}

