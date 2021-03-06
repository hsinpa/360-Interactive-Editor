﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;
using UnityEditor;

namespace _360ExMaker
{
	[CustomNodeEditor(typeof(TimerNode))]
	public class TimerNodeEditor : NodeEditor {
		public override void OnBodyGUI() {
			TimerNode timeNode = (TimerNode)target;

			//NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("inputNode"));

            NodeEditorGUILayout.PortField(target.GetInputPort("inputNode"));

            EditorGUILayout.Space();
			// NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("timeEvents"));

			if (timeNode.timeEvents != null) {
				//target.ClearInstancePorts();
				for (int i = 0; i < timeNode.timeEvents.Length; i++) {


                        var _timeEvent = timeNode.timeEvents[i];

                        NodePort port = target.GetPort("eventnode_" + i);
                        if (port == null)
                        port = target.AddInstanceOutput(typeof(TimerNode.TimeEvent), Node.ConnectionType.Multiple, "eventnode_" + i);

                        NodeEditorGUILayout.PortField(new GUIContent("eventnode_" + i), port);


                        EditorGUILayout.Space();

				}
			}

		}


		
	}
}