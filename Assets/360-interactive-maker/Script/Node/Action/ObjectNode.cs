using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	[CreateNodeMenu("Action/PrefabNode")]
	public class ObjectNode : Node {
		[Input] public TimerNode.TimeEvent inputNode;
		public Vector3 obj_position;
		public Vector3 obj_rotation;

		public GameObject prefab;

		public PositionType obj_position_type;


		[Output] public ObjectNode node;

		public override object GetValue(NodePort port) {
			if (port.fieldName == "node") {
				return this;
			}

			return null;
		}

		public enum PositionType
		{
			World, Local
		}


	}
}