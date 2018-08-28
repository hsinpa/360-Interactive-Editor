using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    [RequireComponent(typeof(Collider))]
    public class TouchObject : BaseInteractObject
    {
        private ObjectNode _objectNode;
        private MediaVideoNode _nextMediaNode;
        public TouchNode _touchNode;

        public override void SetUp(ObjectNode p_objectNode, System.Action<BaseInteractObject, HandObject, MediaNode > p_triggerCallback)
        {
            _objectNode = p_objectNode;
            _triggerCallback = p_triggerCallback;

            //Set nextMediaNode
            if (p_objectNode.GetOutputPort("node").ConnectionCount > 0) {
                _touchNode = (TouchNode) p_objectNode.GetOutputPort("node").Connection.node;

                NodePort connectionPort = _touchNode.GetOutputPort("node").Connection;
                Debug.Log("Connection type " + connectionPort.node.GetType());
                if (connectionPort != null && connectionPort.node.GetType() == typeof(MediaVideoNode))
                {
                    _nextMediaNode = (MediaVideoNode)connectionPort.node;
                }

            }

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == FlagTags.Layer.handLayer && _nextMediaNode != null) {
                if (_triggerCallback != null)
                    _triggerCallback(this, other.GetComponent<HandObject>(),  _nextMediaNode);
            }   
        }

        void OnTriggerExit(Collider other)
        {
        }
    }
}