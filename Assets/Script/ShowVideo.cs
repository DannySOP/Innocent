using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button panelButton;
    public Image thisPanel;
    public GameObject thumbnailPanel;
    public GameObject informationPopUp;
    public int dataNumber;
    public int aNumber;

    private void Start()
    {
        informationPopUp.SetActive(false);

        videoPlayer = GetComponentInChildren<VideoPlayer>();
        panelButton = GetComponent<Button>();
        thisPanel = GetComponent<Image>();

        PanelTransparency();

        StartCoroutine(CallVideoCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url, videoPlayer));
        Debug.Log(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url);
    }

    private void Update()
    {
        if(!informationPopUp.active)
        {
            if(videoPlayer.isPrepared)
            {
                informationPopUp.SetActive(true);
            }
        }
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
        if (videoPlayer.isPrepared)
        {
            if (thumbnailPanel.active)
            {
                thumbnailPanel.SetActive(false);
            }
        }
    }

    public void PanelTransparency()
    {
        Color panelColor = thisPanel.color;
        panelColor.a = 0f;
        thisPanel.color = panelColor;
    }
}
