using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 查找子物体、旋转方法
    /// </summary>
    public class TransformHelper : MonoBehaviour
    {
        /// <summary>
        /// 递归查找子物体
        /// </summary>
        /// <returns>The child.</returns>
        /// <param name="t">T.</param>
        /// <param name="name">Name.</param>
        public static Transform FindChild(Transform t, string name)
        {
            Transform item = null;
            item = t.Find(name);
            if (item != null) return item;
            Transform go = null;
            for (int i = 0; i < t.childCount;i++)
            {
                go = FindChild(t.GetChild(i), name);
                if (go != null)
                    return go;
            }
            return null;
        }
        /// <summary>
        /// 目标的转向方法
        /// </summary>
        /// <returns>The rotation.</returns>
        /// <param name="t">要转向的物体</param>
        /// <param name="target">要看向的物体</param>
        /// <param name="rotationSpeed">旋转速度</param>
        public static void Rotation(Transform t, Vector3 target,float rotationSpeed)
        {
            Quaternion item = Quaternion.LookRotation(target-t.position);
            t.rotation = Quaternion.Lerp(t.rotation, item, rotationSpeed);
        }

        /// <summary>
        /// 泛型查找游戏物体上挂的组件
        /// </summary>
        /// <returns>The child.</returns>
        /// <param name="t">T.</param>
        /// <param name="name">Name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T FindChild<T>(Transform t,string name)
            where T:Component
        {
            Transform go = FindChild(t, name);
            if (go != null)
                return go.GetComponent<T>();
            return null;
        }

    }
}
