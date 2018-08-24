using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker
{

    public class ExMakerVideoView : MonoBehaviour
    {
        VideoPlayer _videoPlayer;

        public void SetUp(  )
        {
            _videoPlayer = GetComponent<VideoPlayer>();
        }

        public void Play(string p_url) {
            _videoPlayer.Stop();

            _videoPlayer.url = p_url;
            _videoPlayer.Play();
        }

        public void Stop() {
            _videoPlayer.Stop();
        }

        //private IEnumerator Play(string p_url, float p_fade_time)
        //{
        //    yield return new WaitForSeconds(p_fade_time);

        //    _videoPlayer.url = p_url;
        //    _videoPlayer.Play();
        //}

    }
}