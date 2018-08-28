using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _360ExMaker { 
    public abstract class BaseInteractObject : MonoBehaviour {
        abstract public void SetUp(ObjectNode p_objectNode, System.Action<BaseInteractObject, HandObject, MediaNode> p_triggerCallback);
        protected System.Action<BaseInteractObject, HandObject, MediaNode> _triggerCallback;
    }
}