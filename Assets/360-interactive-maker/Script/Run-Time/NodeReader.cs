using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    public class NodeReader : MonoBehaviour
    {
        [SerializeField]
        private ExFlowChart _exFlowChart;

        private void Start()
        {
            foreach (Node node in _exFlowChart.nodes) {

            }

            Node firstNode = _exFlowChart.nodes[0];
            NodePort nodeport = firstNode.GetOutputPort("something");
        }







    }

}
