using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	[CreateNodeMenu("Action/Timer")]
	public class TimerNode : Node {
		[Input(connectionType = ConnectionType.Override)] public MediaNode inputNode;

		public TimeEvent[] timeEvents;

		// protected override void Init() {
			

		// 	// if (timeEvents != null) {
		// 	// 	for (int i = 0; i < timeEvents.Length; i++) {
		// 	// 		var _timeEvent = timeEvents[i];
		// 	// 		// AddInstanceOutput(typeof(TimeEvent), ConnectionType.Multiple, "TimeEvent_" + (i+1) );
		// 	// 	}

		// 	// }
		// }	
		[ContextMenu("Add instance output")]
		void AddPort() {
			NodePort port = AddInstanceOutput(typeof(float));
			Debug.Log("Added new output port with name " + port.fieldName);
		}

		[System.Serializable]
		public struct TimeEvent {
			public MediaNode node;
			public float time;
			public float delay;
		}

	}
}