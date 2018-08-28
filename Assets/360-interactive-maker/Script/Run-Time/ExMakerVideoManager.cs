using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker
{

    public class ExMakerVideoManager : MonoBehaviour
    {
        public ExMakerVideoView _videoPlayerView;
        MediaComponent _mediaComponent;
        ObjectHolderManager _objectManager;
        float startPlayTime;

        // Use this for initialization
        public void SetUp(ObjectHolderManager p_objectManager)
        {
            _objectManager = p_objectManager;

            if (_videoPlayerView == null)
                _videoPlayerView = transform.Find("view/video_sphere").GetComponent<ExMakerVideoView>();
        }

        public void PlayMedia(MediaComponent p_mediaComponent) {
            startPlayTime = Time.time;
            _mediaComponent = p_mediaComponent;

            //Prepare prefab to pool if not already exist
            int poolSize = 10;
            List<GameObject> availablePrefab = _mediaComponent.GetAllDistinctObjectPrefab();
            for (int i = 0; i < availablePrefab.Count; i++)
                PoolManager.instance.CreatePool(availablePrefab[i], availablePrefab[i].GetInstanceID(), poolSize);

            _videoPlayerView.Play( _mediaComponent._mediaNode.url );
        }

        private void Update()
        {
            if (_mediaComponent == null) return;
            List<MediaComponent.TimeEventComponent> timeEventComp = _mediaComponent.GetAvailableTimeEvent(startPlayTime);

            if (timeEventComp == null || timeEventComp.Count <= 0) {
                _objectManager.Clear();
                return;
            }

            foreach (MediaComponent.TimeEventComponent comp in timeEventComp)
            {
                foreach (ObjectNode objectNode in comp.interactNode) {
                    _objectManager.SetObject(objectNode);
                }
            }

        }





    }
}