using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class HeadUIManager : MonoBehaviour
{
    [SerializeField] GameObject thisPanel;
    public GameObject loadingImage;
    public GameObject innocentMaps;
    public int dataNumber;
    public int aNumber;
    public VideoPlayer videoPlayer;
    public CameraMovement cameraMovement;
    public bool isVideoOver = false;

    public List<GameObject> miniMap = new List<GameObject>();

    void Start()
    {
        GameObject[] miniMaps = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject miniMapObject in miniMaps)
        {
            if (miniMapObject.CompareTag("MiniMaps"))
            {
                miniMap.Add(miniMapObject);
            }
        }

        thisPanel.SetActive(false);
        loadingImage.SetActive(true);
        innocentMaps.SetActive(false);

        cameraMovement = FindAnyObjectByType<CameraMovement>();
        cameraMovement.enabled = false;

        Invoke("PanelActivated", 1f);

    }
    void Update()
    {
        if(videoPlayer.isPrepared)
            loadingImage.SetActive(false);

        if (!videoPlayer.isLooping && !videoPlayer.isPlaying && videoPlayer.time >= 51.9f)
            VideoIsOver();

        if (isVideoOver)
        {
            if (innocentMaps.active)
            {
                cameraMovement.enabled = false;
                foreach (GameObject map in miniMap)
                {
                    map.SetActive(false);
                }
            }

            if (!innocentMaps.active)
            {
                cameraMovement.enabled = true;
                foreach (GameObject map in miniMap)
                {
                    map.SetActive(true);
                }
            }
        }
    }

    public void PanelActivated()
    {
        thisPanel.SetActive(true);
        Invoke("GetVideo", 0.1f);
    }
    public void GetVideo()
    {
        StartCoroutine(CallVideoCoroutine(WebRequest2.webInstance.dataWrapper.data[dataNumber].A[aNumber].video_url, videoPlayer));
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

    public void VideoIsOver()
    {
        isVideoOver = true;
        thisPanel.SetActive(false);

        cameraMovement.enabled = true;
    }

}
