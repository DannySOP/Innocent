using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class AutoClosePanel : MonoBehaviour
{
    [SerializeField] GameObject thisPanel;
    private VideoPlayer videoPlayer;

    private CameraMovement cameraMovement;
    void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();

        cameraMovement  =FindAnyObjectByType<CameraMovement>();
        cameraMovement.enabled = false;
    }
    void Update()
    {
        if (!videoPlayer.isLooping && !videoPlayer.isPlaying && videoPlayer.time >= 51.9f)
        {
            thisPanel.SetActive(false);

            cameraMovement.enabled = true;
        }
    }

}
