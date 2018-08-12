using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    [CreateAssetMenu]
    public class ExFlowChart : NodeGraph { 

        [ContextMenu ("Do Something")]
        void DoSomething ()
        {
            Debug.Log ("Perform operation");
        }
    }
}

