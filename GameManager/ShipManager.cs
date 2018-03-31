using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using Mono.Data.Sqlite;

namespace DataManager
{
    /// <summary>
    /// 游戏数据管理类
    /// </summary>
    public class ShipManager : GameSingTon<ShipManager>
    {

        /// <summary>
        /// 角色数据列表
        /// </summary>
        public List<CharacterData> characterDatas = new List<CharacterData>();
        /// <summary>
        /// 装备数据列表
        /// </summary>
        public List<EquipData> equipDatas = new List<EquipData>();
        /// <summary>
        /// 购买商品数据列表
        /// </summary>
        public List<EquipData> backPack = new List<EquipData>();

        public CharacterData defultChData;

        DbAccess db;
        private string characterPath = "Character";
        private string equipmentPath = "Equipments";
        private string databaseName = "MySql.db";

        private string path;

        //读取数据库中的数据
        public void Awake()
        {
            path = "Data Source=" + Application.streamingAssetsPath + "/" + databaseName;
#if UNITY_ANDROID
            path = AndriodPaltformSet();
#endif
#if UNITY_EDITOR
            path = "Data Source=" + Application.streamingAssetsPath + "/" + databaseName;
#endif
            try
            {
                Open();
                //读取装备信息
                SqliteDataReader reader = db.ReadFullTable(equipmentPath);
                while (reader.Read())
                {
                    EquipData equipData = new EquipData();
                    equipData.eqID = reader.GetInt32(reader.GetOrdinal("ID"));
                    equipData.eqName = reader.GetString(reader.GetOrdinal("EqName"));
                    equipData.needCoin = reader.GetInt32(reader.GetOrdinal("NeedCoin"));
                    equipData.attack = reader.GetInt32(reader.GetOrdinal("Attack"));
                    equipData.defence = reader.GetInt32(reader.GetOrdinal("Defence"));
                    equipData.addAttack = reader.GetInt32(reader.GetOrdinal("AddAttack"));
                    equipData.moveSpeed = reader.GetInt32(reader.GetOrdinal("MoveSpeed"));
                    equipData.addHP = reader.GetInt32(reader.GetOrdinal("AddHP"));

                    equipDatas.Add(equipData);
                }
                print(equipDatas.Count);
                //读取角色信息
                reader = db.ReadFullTable(characterPath);
                while (reader.Read())
                {
                    CharacterData chData = new CharacterData();
                    chData.name = reader.GetString(reader.GetOrdinal("Name"));
                    chData.HP = reader.GetInt32(reader.GetOrdinal("HP"));
                    chData.SP = reader.GetInt32(reader.GetOrdinal("SP"));
                    chData.moveSpeed = reader.GetInt32(reader.GetOrdinal("MoveSpeed"));
                    chData.rotationSpeed = reader.GetInt32(reader.GetOrdinal("RotationSpeed"));
                    chData.experience = reader.GetInt32(reader.GetOrdinal("Experience"));
                    chData.attack = reader.GetInt32(reader.GetOrdinal("Attack"));
                    chData.attackInv = reader.GetInt32(reader.GetOrdinal("AttackInv"));
                    chData.attackRange = reader.GetInt32(reader.GetOrdinal("AttackRange"));
                    chData.targetRange = reader.GetInt32(reader.GetOrdinal("TargetRange"));
                    //chData.skill01 = reader.GetInt32(reader.GetOrdinal("Skill01"));
                    //chData.skill02 = reader.GetInt32(reader.GetOrdinal("Skill02"));
                    //chData.skill03 = reader.GetInt32(reader.GetOrdinal("Skill03"));
                    //chData.skill04 = reader.GetInt32(reader.GetOrdinal("Skill04"));

                    characterDatas.Add(chData);
                }
                print(characterDatas.Count);
            }
            catch (Exception e)
            {
                print(e.ToString());
                db.CloseSqlConnection();
            }
            db.CloseSqlConnection();
        }
        private void Open()
        {
            db = new DbAccess(path);
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

        ///////////////////////////////////////////对列表的相关操作

        //public List<CharacterData> GetCharacterData
        //{
        //    get{
        //        return characterDatas;
        //    }
        //}
        //public List<EquipData> GetEquipData
        //{
        //    get{
        //        return equipDatas;
        //    }
        //}
        ////public 
    }
}
