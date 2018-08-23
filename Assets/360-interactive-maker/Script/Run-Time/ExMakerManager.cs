using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace _360ExMaker { 

    public class ExMakerManager : MonoBehaviour {

        NodeReader _nodeReader;
        VideoPlayer _videoPlayer;

        private void Start()
        {
            _nodeReader = transform.Find("model/node_reader").GetComponent<NodeReader>();
            _videoPlayer = transform.Find("view/video_sphere").GetComponent<VideoPlayer>();

            if (_nodeReader != null)
                Init();
        }

        private void Init() {
            _nodeReader.SetUp();
        }
        


    }
}