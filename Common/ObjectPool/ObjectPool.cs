using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 对象池 （处理频繁使用的游戏物体 如：子弹 技能  敌人）
    /// </summary>
    public class ObjectPool : MonoSingTon<ObjectPool>
    {
        private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();
        /// <summary>
        /// 创建需要显示的对象
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">对象名称</param>
        /// <param name="go">对象的预制体</param>
        /// <param name="position">对象的新位置</param>
        /// <param name="quaternion">对象的新角度</param>
        public GameObject CreateObject(string key,GameObject go,Vector3 position,Quaternion quaternion)
        {
            GameObject tempGo = FindUseObj(key);
            if(tempGo!=null)
            {
                tempGo.transform.position = position;
                tempGo.transform.rotation = quaternion;
            }
            else
            {
                tempGo = Instantiate(go, position, quaternion) as GameObject;
                Add(key,tempGo);
            }
            tempGo.SetActive(true);
            return tempGo;
        }
        /// <summary>
        /// 为对象池添加元素
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="key">名称</param>
        /// <param name="tempGo">预制体</param>
        public void Add(string key,GameObject tempGo)
        {
            if(!cache.ContainsKey(key))
            {
                cache.Add(key, new List<GameObject>());
            }
            cache[key].Add(tempGo);

        }
        /// <summary>
        /// 在对象池中寻找可以使用的对象
        /// </summary>
        /// <returns>The use object.</returns>
        /// <param name="key">名称</param>
        public GameObject FindUseObj(string key)
        {
            if (cache.ContainsKey(key))
                //找到对象池中一个没有激活的对象
                return cache[key].Find(p => !p.activeSelf);
            return null;
        }
        /// <summary>
        /// 直接回收
        /// </summary>
        /// <param name="go">Go.</param>
        public void CollectObject(GameObject go)
        {
            go.SetActive(false);
        }
        /// <summary>
        /// 延迟回收
        /// </summary>
        /// <param name="go">回收对象</param>
        /// <param name="delay">延迟时间</param>
        public void CollectObject(GameObject go,float delay)
        {
            StartCoroutine(Collect(go,delay));
        }
        private IEnumerator Collect(GameObject go,float delay)
        {
            yield return new WaitForSeconds(delay);
            CollectObject(go);;
        }
        /// <summary>
        /// 释放资源（例如删除一个技能）
        /// </summary>
        /// <returns>The clear.</returns>
        /// <param name="key">Key.</param>
        public void Clear(string key)
        {
            if(cache.ContainsKey(key))
            {
                for (int i = 0; i < cache[key].Count; i++)
                {
                    //删除游戏物体
                    Destroy(cache[key][i]);
                }
                cache.Remove(key);
            }
        }
        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void ClearAll()
        {
            //获取到所有的键
            var list = new List<string>(cache.Keys);
            for (int i = 0; i < list.Count;i++)
            {
                Clear(list[i]);
            }
        }
    }
}
