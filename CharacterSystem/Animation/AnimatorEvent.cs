using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Character
{
    public class AnimatorEvent : MonoBehaviour
    {
        //基本配置物体
        private GameObject fireSpray;
        // Use this for initialization
        void Start()
        {
            //获取喷火点
            fireSpray = TransformHelper.FindChild(transform, "FireSpray").gameObject;
        }

        //开始喷火
        public void StartFire()
        {
            fireSpray.gameObject.SetActive(true);
        }
        //停止喷火
        public void StopFire()
        {
            fireSpray.gameObject.SetActive(false);

        }
    }
}
