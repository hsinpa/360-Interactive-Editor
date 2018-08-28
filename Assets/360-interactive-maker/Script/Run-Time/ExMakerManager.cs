using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker { 

    public class ExMakerManager : MonoBehaviour {

        NodeReader _nodeReader;
        ExMakerVideoManager _videoPlayer;
        ObjectHolderManager _objectHolderManager;

        private void Start()
        {
            _nodeReader = transform.Find("model/node_reader").GetComponent<NodeReader>();
            _objectHolderManager = transform.Find("view/interact_object_holder").GetComponent<ObjectHolderManager>();
            _videoPlayer = GetComponent<ExMakerVideoManager>();

            _objectHolderManager.SetUp(this);

            if (_nodeReader != null)
                Init();
        }

        private void Init() {
            _nodeReader.SetUp();
            _videoPlayer.SetUp(_objectHolderManager);

            PlayNextMedia(_nodeReader.currentMediaComponent);

        }

        public MediaComponent ParsMediaNode(MediaNode p_node) {
            return _nodeReader.Parse(p_node);
        }

        public void PlayNextMedia(MediaComponent p_mediaComponent) {
            if (p_mediaComponent == null) return;
            _videoPlayer.PlayMedia(p_mediaComponent);
        }

    }
}