using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateNodeMenu("SampleButton")]
public class SimpleNode : Node {
    [Input] public float value;
    [Output] public float result;


    public override object GetValue(NodePort port) {
        // Check which output is being requested. 
        // In this node, there aren't any other outputs than "result".
        if (port.fieldName == "result") {
            // Return input value + 1
            return GetInputValue<float>("value", this.value) + 1;
        }

		return null;
    }


}