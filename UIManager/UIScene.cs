using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using System;

namespace UI
{
    public class UIScene : MonoBehaviour
    {
        //存储被监听对象
        private Dictionary<string, OnTriggerEvent> UIEventTriggers = new Dictionary<string, OnTriggerEvent>();

        //数据库操作
        private DbAccess db;
        private string path;
        private string databaseName = "MySql.db";
        //账户表
        private string table_User;
        //装备表
       // private string table_Equip;

        // Use this for initialization
        protected void Start()
        {
            FindALLUIEventTrigger(transform);
        }
        ///////////////////////////////////////////////////////////////////数据库中各个表的路径
        /// <summary>
        /// 提供数据库登录信息路径
        /// </summary>
        public void MySqlLoginPath()
        {
            //数据库
            path = "Data Source=" + Application.streamingAssetsPath + "/"+databaseName;
#if UNITY_ANDROID
            path = AndriodPaltformSet();
#endif
            table_User = "Players";
        }
        //递归查找子物体(OnTriggerEvent)
        public void FindALLUIEventTrigger(Transform t)
        {
            OnTriggerEvent temp = t.GetComponent<OnTriggerEvent>();
            if(temp!=null)
            {
                UIEventTriggers.Add(temp.name,temp);
            }
            for (int i = 0; i < t.childCount;i++)
            {
                FindALLUIEventTrigger(t.GetChild(i));
            }
        }

        //提供获取(OnTriggerEvent)目标控件的接口
        public OnTriggerEvent GetUIEventTrigger(string name)
        {
            if(UIEventTriggers.ContainsKey(name))
            {
                return UIEventTriggers[name];
            }
            return null;
        }
        //安卓平台数据库设置
        public string AndriodPaltformSet()
        {
            string path = "URI = file:" + Application.persistentDataPath + "/" + databaseName;
            //Android APK中数据库文件的路径
            string androidPath = "jar:file://" + Application.dataPath + "!/assets/" + databaseName;
            //Android沙盒路径
            string androidFilePath = Application.persistentDataPath + "/" + databaseName;
            //如果Android项目源文件中不存在数据库文件，说明没有加载过，需要加载
            if (!File.Exists(androidFilePath))
            {
                //从APK路径拿到Sqlite数据库文件，下载
                WWW www = new WWW(androidPath);
                //下载未完成时，保持等待
                while (!www.isDone)
                {
                }
                //下载完成，IO流写入到沙盒路径
                File.WriteAllBytes(androidFilePath, www.bytes);
            }
            return path;
        }

        /// <summary>
        /// 登录游戏在数据库中查找
        /// </summary>
        //public void Open()
        //{
        //    db = new DbAccess(path);
        //}
        ////提供账户验证
        //public void Login_SelectSql(string name, string password)
        //{
        //    try
        //    {
        //        Open();
        //        SqliteDataReader reader = db.Select(table_User, "Name", "'" + name + "'");
        //        if(reader.Read())
        //        {
        //            if(reader.GetString(reader.GetOrdinal("PassWord"))==password)
        //            {
        //                //同步加载
        //                //SceneNumber.Instance.ChangScene(SceneNumber.Instance.depotShip);
        //                //SceneManager.LoadScene("Loading");
        //                SceneNumber.Instance.ChangScene(SceneNumber.Instance.depotShip);
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        print("登录失败");
        //        db.CloseSqlConnection();
        //    }
        //    db.CloseSqlConnection();
        //}
        ////提供账户注册
        //public void Register_InsertSql(string name,string password)
        //{
        //    try
        //    {
        //        Open();
        //        SqliteDataReader reader = db.Select(table_User, "Name", "==", "'" + name + "'");
        //        if (reader.Read())
        //        {
        //            print("用户名已经存在");
        //        }
        //        else
        //        {
        //            db.InsertInto(table_User, new string[] { "'" + name + "'", "'" + password + "'" });
        //            UIManager.Instance.UIsceneSetActive(SceneName.Panel_Login);
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        print("注册失败");
        //        db.CloseSqlConnection();
        //    }
        //    db.CloseSqlConnection();
        //}
    }
}
