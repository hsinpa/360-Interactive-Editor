using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    [CreateAssetMenu]
    public class ExFlowChart : NodeGraph {

        public MediaNode currentDefaultNode;
        public Color currentDefaultColor;
        public Color nonDefaultColor;

        //[ContextMenu("Do Something")]
        //void DoSomething()
        //{
        //    Debug.Log("Perform operation");
        //}

        public void SetAsDefault(MediaNode p_mediaNode) {
            if (currentDefaultNode != null)
                currentDefaultNode.name = currentDefaultNode.originalName;

            currentDefaultNode = p_mediaNode;
        }

        public MediaNode GetRootNode() {
            if (currentDefaultNode != null)
                return currentDefaultNode;

            foreach(Node n in nodes) {
                if (n.GetType() == typeof(MediaNode))
                    return (MediaNode) n;
            }

            return null;
        }

    }
}

