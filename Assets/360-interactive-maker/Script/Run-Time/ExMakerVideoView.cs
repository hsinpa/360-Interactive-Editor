using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker
{

    public class ExMakerVideoView : MonoBehaviour
    {
        VideoPlayer _videoPlayer {
            get {
                return GetComponent<VideoPlayer>();
            }
        }

        public void Play(string p_url) {
            _videoPlayer.Stop();

            _videoPlayer.url = p_url;
            //_videoPlayer.Prepare();
            //_videoPlayer.prepareCompleted += PrepareComplete;
            _videoPlayer.Play();
        }

        public void Stop() {
            _videoPlayer.Stop();
        }

        private void PrepareComplete(VideoPlayer p_source) {
            p_source.Play();
        }
        //private IEnumerator Play(string p_url, float p_fade_time)
        //{
        //    yield return new WaitForSeconds(p_fade_time);

        //    _videoPlayer.url = p_url;
        //    _videoPlayer.Play();
        //}

    }
}