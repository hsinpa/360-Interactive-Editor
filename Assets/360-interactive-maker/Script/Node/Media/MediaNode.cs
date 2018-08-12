using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	public abstract class MediaNode : Node {
		[Input(connectionType = ConnectionType.Override)] public string url;
		[Input(connectionType = ConnectionType.Override)] public Node inputNode;


		[Output] public MediaNode node;

		public override object GetValue(NodePort port) {
			if (port.fieldName == "node") {
				return this;
			}

			return null;
		}



	}
}