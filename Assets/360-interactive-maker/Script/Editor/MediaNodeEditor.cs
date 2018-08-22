using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;
using UnityEditor;

namespace _360ExMaker
{
    [CustomNodeEditor(typeof(MediaNode))]
    public class MediaNodeEditor : NodeEditor
    {
 
        public override Color GetTint()
        {
            MediaNode mediaNode = (MediaNode)target;
            ExFlowChart exflowChart = mediaNode.graph as ExFlowChart;

            return (exflowChart.currentDefaultNode == mediaNode) ? exflowChart.currentDefaultColor : exflowChart.nonDefaultColor;
        }

    }
}