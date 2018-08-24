using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	[CreateNodeMenu("Action/Interactive/TouchNode")]
	public class TouchNode : Node {
		[Input] public ObjectNode inputNode;

		public float velocity_strenth;
		public float hold_time;


        [Output(connectionType = ConnectionType.Override)] public Node node;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "node")
            {
                return this;
            }

            return null;
        }

    }
}