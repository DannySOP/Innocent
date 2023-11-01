using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button panelButton;
    public int dataNumber;
    public int aNumber;

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        panelButton = GetComponent<Button>();
        StartCoroutine(CallVideoCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url, videoPlayer));
        Debug.Log(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url);
    }

    public void GetVideo()
    {
        StartCoroutine(CallVideoCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url, videoPlayer));
        Debug.Log("jalan");
    }

    private IEnumerator CallVideoCoroutine(string url, VideoPlayer video)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(url);
            Debug.Log(www.error);
        }
        else
        {
            video.url = url;
            video.Prepare();
        }
    }
    
    public void PlayPauseVideo()
    {
        if(!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        else if(videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
    }
}
