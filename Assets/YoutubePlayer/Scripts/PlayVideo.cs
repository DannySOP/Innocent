using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace YoutubePlayer
{
    public class PlayVideo : MonoBehaviour
    {
        [SerializeField] TMP_Text buttonText;
        public VideoPlayer videoPlayer;

        Button m_Button;

        void Awake()
        {
            m_Button = GetComponent<Button>();
            m_Button.interactable = videoPlayer.isPrepared;
            videoPlayer.prepareCompleted += VideoPlayerOnPrepareCompleted;
        }

        void VideoPlayerOnPrepareCompleted(VideoPlayer source)
        {
            m_Button.interactable = videoPlayer.isPrepared;
        }

        public void Play()
        {
            videoPlayer.Play();
        }

        public void Pause()
        {
            videoPlayer.Pause();
        }

        public void PlayPausePressed()
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                buttonText.text = "Play";
            }
            else if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                buttonText.text = "Pause";
            }
        }

        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerOnPrepareCompleted;
        }
    }
}
