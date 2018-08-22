using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
	[CreateNodeMenu("Action/Timer"), NodeTint("#CCFFCC")]
	public class TimerNode : Node {
		[Input(connectionType = ConnectionType.Override)] public MediaNode inputNode;

		public TimeEvent[] timeEvents;

        public override object GetValue(NodePort port)
        {


            if (port.fieldName.StartsWith("eventnode_"))
            {

                string[] pair = port.fieldName.Split(new string[] { "_" }, System.StringSplitOptions.None);

                if (pair.Length > 1 && timeEvents.Length > int.Parse(pair[1]))
                {
                    return timeEvents[int.Parse(pair[1])];
                }

            }

            return null;
        }

        [System.Serializable]
		public struct TimeEvent {
			public MediaNode node;
			public float time;
			public float delay;
		}

	}
}