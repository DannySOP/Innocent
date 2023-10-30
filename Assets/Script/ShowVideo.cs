using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class ShowVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button panelButton;
    public int blockNumber;
    public int libraryNumber;

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        panelButton = GetComponent<Button>();

        StartCoroutine(CallVideoCoroutine("http://localhost:1337" + WebRequest.Instance.dataWrapper.data[0].attributes.blocks[blockNumber].library[libraryNumber].image.data.attributes.url, videoPlayer));
    }

    public void CallVideo()
    {
        StartCoroutine(CallVideoCoroutine("http://localhost:1337" + WebRequest.Instance.dataWrapper.data[0].attributes.blocks[blockNumber].library[libraryNumber].image.data.attributes.url, videoPlayer));
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
            // Assuming you have a RawImage component to display the video on
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
