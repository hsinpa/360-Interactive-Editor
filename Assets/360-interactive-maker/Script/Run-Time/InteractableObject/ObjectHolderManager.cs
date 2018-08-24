using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolderManager : MonoBehaviour {

    private PoolManager pooling;
    private Dictionary<string, GameObject> objectDict ;

    

    public bool HasKey(string p_key) {
        return objectDict.ContainsKey(p_key);
    }

    
}
