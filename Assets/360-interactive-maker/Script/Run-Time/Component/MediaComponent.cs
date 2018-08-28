using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using System.Linq;

namespace _360ExMaker
{
    public class MediaComponent {
        public MediaNode _mediaNode;
        public TimerNode _timeNode;

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

                for (int i = 0; i < _timeNode.timeEvents.Length; i++) {
                    NodePort timerport = _timeNode.GetOutputPort("eventnode_" + i);
                    if (timerport.ConnectionCount <= 0) continue;

                    ObjectNode[] objectNodes = new ObjectNode[timerport.ConnectionCount];
                    for (int c = 0; c < timerport.ConnectionCount; c++) {
                        objectNodes[c] = (ObjectNode) timerport.GetConnection(c).node;
                    }
                    _timeEvents.Add(new TimeEventComponent((TimerNode.TimeEvent) timerport.GetOutputValue(), objectNodes) );
                }
            }
        }

        public List<GameObject> GetAllDistinctObjectPrefab()
        {
            List<GameObject> objectPrefabList = new List<GameObject>();
            for (int i = 0; i < _timeEvents.Count; i++) {
                foreach (ObjectNode interactNode in _timeEvents[i].interactNode) {
                    if (!objectPrefabList.Contains(interactNode.prefab))
                        objectPrefabList.Add(interactNode.prefab);
                }
            }
            return objectPrefabList;
        }

        public List<TimeEventComponent> GetAvailableTimeEvent(float p_given_timestamp) {
            float playedTime = Time.time - p_given_timestamp;

            return _timeEvents.FindAll(x => playedTime >= x.timeEvent.time && playedTime < (x.timeEvent.time + x.timeEvent.delay));
        }

        public class TimeEventComponent {
            public TimerNode.TimeEvent timeEvent;
            public ObjectNode[] interactNode;

            public TimeEventComponent(TimerNode.TimeEvent timeEvent, ObjectNode[] interactNode)
            {
                this.timeEvent = timeEvent;
                this.interactNode = interactNode;
            }
        }
    }
}