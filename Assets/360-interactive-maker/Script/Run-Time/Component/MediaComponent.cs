using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    public class MediaComponent {
        MediaNode _mediaNode;
        TimerNode _timeNode;

        private List<TimeEventComponent> _timeEvents = new List<TimeEventComponent>();

        public MediaComponent(MediaNode p_mediaNode)
        {
            _mediaNode = p_mediaNode;

            ParseMediaNode(_mediaNode);
        }

        protected virtual void ParseMediaNode(MediaNode p_mediaNode) {
            NodePort port = p_mediaNode.GetOutputPort("node");
            if (port.ConnectionCount > 0) {
                _timeNode = (TimerNode)port.Connection.node;
                Debug.Log("Time node name " + _timeNode.name);

                for (int i = 0; i < _timeNode.timeEvents.Length; i++) {
                    Debug.Log("eventnode_" + i);
                    NodePort timerport = _timeNode.GetOutputPort("eventnode_" + i);
                    if (timerport.ConnectionCount <= 0) continue;

                    ObjectNode[] objectNodes = new ObjectNode[timerport.ConnectionCount];
                    for (int c = 0; c < timerport.ConnectionCount; c++) {
                        objectNodes[c] = (ObjectNode) timerport.GetConnection(i).node;
                    }
                    _timeEvents.Add(new TimeEventComponent((TimerNode.TimeEvent) timerport.GetOutputValue(), objectNodes) );
                }
            }
        }

        public class TimeEventComponent {
            TimerNode.TimeEvent timeEvent;
            ObjectNode[] interactNode;

            public TimeEventComponent(TimerNode.TimeEvent timeEvent, ObjectNode[] interactNode)
            {
                this.timeEvent = timeEvent;
                this.interactNode = interactNode;
            }
        }
    }
}