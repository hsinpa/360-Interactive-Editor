using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace _360ExMaker
{
    public class NodeReader : MonoBehaviour
    {
        [SerializeField]
        private ExFlowChart _exFlowChart;
        private MediaComponent currentMediaComponent;

        public void SetUp()
        {
            if (_exFlowChart.nodes.Count <= 0)
                return;


            Node defaultNode = _exFlowChart.currentDefaultNode;
            if (defaultNode == null) {
                defaultNode = _exFlowChart.nodes.Find(x => x.GetType() == typeof(MediaNode));
                //Stop, if can't find any medianode
                if (defaultNode == null) return;
            }

            Debug.Log("Default node name " + defaultNode.name);

            currentMediaComponent = new MediaComponent((MediaNode) defaultNode);
        }

        private void Update()
        {
            if (currentMediaComponent != null) {
                

            }
        }


    }

}
