using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class AutoClosePanel : MonoBehaviour
{
    [SerializeField] GameObject thisPanel;
    private VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isLooping && !videoPlayer.isPlaying && videoPlayer.time >= 51.9f)
        {
            thisPanel.SetActive(false);
        }
    }

}
