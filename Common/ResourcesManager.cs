using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Tools
{
    /// <summary>
    /// 管理所有资源 （进行资源加载）
    /// </summary>
    public class ResourcesManager : MonoBehaviour
    {
        /// <summary>
        /// key=预制体名称，value=路径
        /// </summary>
        static Dictionary<string, string> mapName = new Dictionary<string, string>();
        /// <summary>
        /// 加载预制体对应表并存放在字典中
        /// </summary>
        private static void ReadText()
        {
            //加载TextAsset文件
            string mapText = Resources.Load<TextAsset>("AssetsName").text;
            string line = null;
            StringReader sReader = new StringReader(mapText);

            while((line=sReader.ReadLine())!=null)
            {
                var item = line.Split('=');
                mapName.Add(item[0].Trim(),item[1].Trim());
            }
        }
        /// <summary>
        /// 加载游戏物体
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="name">Name.</param>
        public static Object Load(string name)
        {
            if(mapName.ContainsKey(name))
            {
                return Resources.Load(mapName[name]);
            }
            return null;
        }
        /// <summary>
        /// 泛型加载方法
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="name">Name.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Load<T>(string name) where T:Object
        {
            if(mapName.ContainsKey(name))
            {
                return Resources.Load<T>(mapName[name]);
            }
            return null;
        }
        private static string GetPath(string name)
        {
            if (mapName.ContainsKey(name)) 
            {
                return mapName[name];
            }
            return null;
        }
    }
}
