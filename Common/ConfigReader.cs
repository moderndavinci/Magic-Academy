using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// 读取配置文件(所有的配置文件都放到一个字典中（状态表、技能预制件等）)
    /// </summary>
    public class ConfigReader
    {
        //例如
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>>
        config = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

        public static Dictionary<string,Dictionary<string,string>> loadALL(string aiConfigfile)
        {
            if(config.ContainsKey(aiConfigfile))
            {
                return config[aiConfigfile];
            }
            var configPath = Path.Combine(Application.streamingAssetsPath, aiConfigfile);
            if(Application.platform!=RuntimePlatform.Android)
            {
                configPath = "file://" + configPath;
            }
            //加载本地文件
            WWW www = new WWW(configPath);
            while(true)
            {
                if(!string.IsNullOrEmpty(www.error))
                {
                    //弹出错误信息
                    throw new System.Exception(www.error);
                }
                if(www.isDone)
                {
                    var tempDic = BuildDic(www.text);
                    config.Add(aiConfigfile, tempDic);
                    return tempDic;
                }

            }
        }
        private static Dictionary<string,Dictionary<string,string>> BuildDic(string lines)
        {
            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
            string mainKey = null;
            string subKey = null;
            string subValue = null;
            //将Text文件添加到StreamReader中
            StreamReader sReader = new StreamReader(lines);
            string line = null;
            //一行一行读取，添加到字典中
            while((line=sReader.ReadLine())!=null)
            {
                //将获取到的一行去除首尾空字符
                line = line.Trim();
                //判断该行是否为空
                if(!string.IsNullOrEmpty(line))
                {
                    if(line.StartsWith("["))
                    {
                        mainKey = line.Substring(1, line.IndexOf("]") - 1);
                        dic.Add(mainKey,new Dictionary<string, string>());
                    }
                    else{
                        //按照‘>’分隔并去除空字符
                        var configValue = line.Split(new char[] { '>' }, System.StringSplitOptions.RemoveEmptyEntries);
                        subKey = configValue[0].Trim();
                        subValue = configValue[1].Trim();
                        dic[mainKey].Add(subKey, subValue);
                    }
                }
            }
            return dic;
        }

    }
}
