using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker
{

    public class ExMakerVideoManager : MonoBehaviour
    {
        ExMakerVideoView _videoPlayerView;
        MediaComponent _mediaComponent;
        NodeReader _nodeReader;
        float startPlayTime;

        // Use this for initialization
        public void SetUp(NodeReader nodeReader)
        {
            _nodeReader = nodeReader;
            _videoPlayerView = transform.Find("view/video_sphere").GetComponent<ExMakerVideoView>();
        }

        public void PlayMedia(MediaComponent p_mediaComponent) {
            startPlayTime = Time.time;
            _mediaComponent = p_mediaComponent;

            int poolSize = 10;
            List<GameObject> availablePrefab = _mediaComponent.GetAllDistinctObjectPrefab();
            for (int i = 0; i < availablePrefab.Count; i++)
                PoolManager.instance.CreatePool(availablePrefab[i], availablePrefab[i].GetInstanceID(), poolSize);
        }

        private void Update()
        {
            if (_mediaComponent == null) return;
            List<MediaComponent.TimeEventComponent> timeEventComp = _mediaComponent.GetAvailableTimeEvent(startPlayTime);

            if (timeEventComp == null || timeEventComp.Count <= 0) return;


        }





    }
}