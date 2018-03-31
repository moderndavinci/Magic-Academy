using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 相机的跟随
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        private Transform player;
        private Vector3 offSet;
        public float smooth;
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            offSet = transform.position - player.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            transform.position=player.position+offSet;
        }
     }
}
