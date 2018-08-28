using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace _360ExMaker
{
    public class HandObject : MonoBehaviour
    {

        public float velocity = 0;
        private Vector3 lastFramePosition;
        private void Start()
        {
            gameObject.layer = FlagTags.Layer.handLayer;
        }

        private void FixedUpdate()
        {
            velocity = ( (transform.position - lastFramePosition) / Time.deltaTime ).sqrMagnitude;
            lastFramePosition = transform.position;
        }


    }
}