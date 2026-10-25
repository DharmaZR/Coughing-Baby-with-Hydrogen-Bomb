using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class LoreSceneController : MonoBehaviour
{

    [SerializeField] private VideoPlayer loreVideoPlayer;
    [SerializeField] private string nextScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loreVideoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
}
