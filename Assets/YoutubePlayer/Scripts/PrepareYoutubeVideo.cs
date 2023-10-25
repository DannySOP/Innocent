using UnityEngine;

namespace YoutubePlayer
{
    public class PrepareYoutubeVideo : MonoBehaviour
    {
        public YoutubePlayer youtubePlayer;

        private void Awake()
        {
            Prepare();
        }

        public async void Prepare()
        {
            Debug.Log("Loading video...");
            await youtubePlayer.PrepareVideoAsync();
            Debug.Log("Video ready");
        }
    }
}
