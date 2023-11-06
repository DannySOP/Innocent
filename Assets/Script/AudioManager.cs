using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    [SerializeField] AudioSource bgm;
    public List<VideoPlayer> videoPlayers = new List<VideoPlayer>();

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }

    private void Start()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        // Get all VideoPlayers in the scene and add them to the list
        VideoPlayer[] videoPlayersArray = Resources.FindObjectsOfTypeAll<VideoPlayer>();
        videoPlayers.AddRange(videoPlayersArray);
    }

    private void Update()
    {
        CheckVideoPlayersStatus();
    }

    public void PlayBGM(AudioClip clip, bool loop)
    {
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }

        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void SetMute(bool value)
    {
        bgm.mute = value;
    }

    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
    }

    public void CheckVideoPlayersStatus()
    {
        bool isAnyVideoPlaying = false;

        // Check if any VideoPlayer is playing
        foreach (VideoPlayer videoPlayer in videoPlayers)
        {
            if (videoPlayer.isPlaying)
            {
                isAnyVideoPlaying = true;
                break; // Exit the loop as soon as a playing video is found
            }
        }

        if (isAnyVideoPlaying)
        {
            // If any VideoPlayer is playing, pause the BGM
            PauseBGM();
        }
        else
        {
            // If no VideoPlayer is playing, resume the BGM
            ResumeBGM();
        }
    }

    private void PauseBGM()
    {
        if (bgm.isPlaying)
        {
            bgm.Pause();
        }
    }

    private void ResumeBGM()
    {
        if (!bgm.isPlaying)
        {
            bgm.UnPause();
        }
    }
}
