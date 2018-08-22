using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    public abstract class MediaNode : Node {
        [Input(connectionType = ConnectionType.Override)] public string url;
        [Input(connectionType = ConnectionType.Override)] public Node inputNode;

        [Output(connectionType = ConnectionType.Override)] public MediaNode node;

        public string originalName="";

        public override object GetValue(NodePort port) {
            if (port.fieldName == "node") {
                return this;
            }

            return null;
        }

        protected override void Init()
        {
            base.Init();
            if (originalName == "")
                originalName = "Media Video node";
        }

        [ContextMenu("SetAsDefault")]
        protected void SetAsDefault() {
            SetAsDefault(true);
        }

        protected void SetAsDefault(bool p_force) {
            ExFlowChart mGraph = (ExFlowChart)graph;

            if (p_force) {
                mGraph.SetAsDefault(this);
                name = "(Default) " + originalName;
            }
            else
            {
                Debug.Log(mGraph.name);
                if (mGraph.currentDefaultNode == null) {
                    name = "(Default) " + originalName;
                    mGraph.SetAsDefault(this);
                }
            }
        }

    }
}