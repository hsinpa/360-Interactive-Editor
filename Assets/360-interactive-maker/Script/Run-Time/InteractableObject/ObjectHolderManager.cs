using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _360ExMaker
{

    public class ObjectHolderManager : MonoBehaviour
    {

        private PoolManager pooling;
        private Dictionary<int, GameObject> objectDict = new Dictionary<int, GameObject>();
        private ExMakerManager maker;


        public void SetUp(ExMakerManager p_maker) {
            maker = p_maker;
        }

        public bool HasKey(int p_key)
        {
            return objectDict.ContainsKey(p_key);
        }

        public void SetObject(ObjectNode p_object_node)
        {
            int objectNodeID = p_object_node.GetInstanceID();
            int prefabKey = p_object_node.prefab.GetInstanceID();

            GameObject objectPrefab;
            if (!objectDict.TryGetValue(objectNodeID, out objectPrefab))
            {
                objectPrefab = PoolManager.instance.ReuseObject(prefabKey);
                objectDict.Add(objectNodeID, objectPrefab);
                objectPrefab.SetActive(true);
                objectPrefab.transform.SetParent(this.transform);

                BaseInteractObject interactObject = objectPrefab.GetComponent<BaseInteractObject>();
                if (interactObject != null)
                    interactObject.SetUp(p_object_node, TouchTriggerEvent);

                if (p_object_node.obj_position_type == ObjectNode.PositionType.Local) {
                    objectPrefab.transform.localPosition = p_object_node.obj_position;
                    objectPrefab.transform.localRotation = Quaternion.Euler(p_object_node.obj_rotation);
                }
                else {
                    objectPrefab.transform.position = p_object_node.obj_position;
                    objectPrefab.transform.rotation = Quaternion.Euler(p_object_node.obj_rotation);
                }
            }
            
        }

        public void Clear() {
            foreach (var item in objectDict)
            {
                PoolManager.instance.Destroy(item.Value);
            }

            //Remove anything that's not being pool
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
                GameObject.Destroy(transform.GetChild(i).gameObject);
        }

        private void TouchTriggerEvent(BaseInteractObject p_interactObject, HandObject p_handObject, MediaNode p_next_node) {
            //Check if intercaatObject fulfill requirement
            if (typeof(TouchObject) == p_interactObject.GetType())
            {
                TouchObject touchObject = (TouchObject)p_interactObject;
                if (p_handObject.velocity < touchObject._touchNode.velocity_strenth)
                    return;
            }
            else {
                return;
            }



            if (p_next_node.GetType() == typeof(MediaVideoNode)) {
                MediaComponent mc = maker.ParsMediaNode(p_next_node);
                maker.PlayNextMedia(mc);
            }

        }
    }
}