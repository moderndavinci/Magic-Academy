using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using Tools;
using System.IO;

namespace Character.Skill
{
    /// <summary>
    /// 技能管理类
    /// </summary>
    public class CharacterSkillManager : MonoBehaviour
    {
        //所有的技能数据列表
        public List<SkillData> skills = new List<SkillData>();
        //数据库
        private DbAccess db;
        private string path;
        private string databaseName = "MySql.db";
        private string table_SkillData;
        /// <summary>
        /// 从数据库里读取技能数据
        /// </summary>
        public void Awake()
        {
            path = @"Data Source=" + Application.streamingAssetsPath + "/" + databaseName;
#if UNITY_ANDROID
            path = AndriodPaltformSet();
#endif
#if UNITY_EDITOR
            path = "Data Source=" + Application.streamingAssetsPath + "/" + databaseName;
#endif
            table_SkillData = "CharacterSkills";
            try
            {
                //进行技能配置的读取
                Open();
                SqliteDataReader reader = db.ReadFullTable(table_SkillData);
                //一行一行的读取直到读取到最后的一行
                while (reader.Read())
                {
                    SkillData skillData = new SkillData();
                    skillData.skillID = reader.GetInt32(reader.GetOrdinal("SkillID"));
                    skillData.skillName = reader.GetString(reader.GetOrdinal("SkillName"));
                    skillData.skillDescription = reader.GetString(reader.GetOrdinal("SkillDescription"));
                    skillData.skillCoolTime = reader.GetInt32(reader.GetOrdinal("SkillCoolTime"));
                    skillData.skillCoolRemain = reader.GetInt32(reader.GetOrdinal("SkillCoolRemain"));
                    skillData.skillCostSP = reader.GetInt32(reader.GetOrdinal("SkillCostSP"));
                    skillData.skillAttackDistance = reader.GetInt32(reader.GetOrdinal("SkillAttackDistance"));
                    skillData.skillAttackAngle = reader.GetInt32(reader.GetOrdinal("SkillAttackAngle"));
                    skillData.skillAttackTargetTags = reader.GetString(reader.GetOrdinal("SkillAttackTargetTags")).Split('/');
                    skillData.skillDamage = reader.GetInt32(reader.GetOrdinal("SkillDamage"));
                    skillData.skillDurationTime = reader.GetInt32(reader.GetOrdinal("SkillDurationTime"));
                    skillData.skillPerfabName = reader.GetString(reader.GetOrdinal("SkillPerfabName"));
                    skillData.skillHitFxName = reader.GetString(reader.GetOrdinal("SkillHitFxName"));
                    skillData.skillAnimationName = reader.GetString(reader.GetOrdinal("SkillAnimationName"));
                    skillData.skillLevel = reader.GetInt32(reader.GetOrdinal("SkillLevel"));
                    skillData.skillActivated = reader.GetBoolean(reader.GetOrdinal("SkillActivated"));
                    skillData.skillAttackType = (SkillAttackType)Enum.Parse(typeof(SkillAttackType),reader.GetString(reader.GetOrdinal("SkillAttackType")));
                    skillData.skillDamageMode = (SkillDamageMode)Enum.Parse(typeof(SkillDamageMode), reader.GetString(reader.GetOrdinal("SkillDamageMode")));

                    skills.Add(skillData);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                db.CloseSqlConnection();
            }
            db.CloseSqlConnection();
        }
        public void Open()
        {
            db = new DbAccess(path);
        }
        public void Start()
        {
            //技能对象 初始化 （技能预制体，受击点预制体，技能拥有者）
            foreach (var skill in skills)
            {
                if (!string.IsNullOrEmpty(skill.skillPerfabName) && skill.skillPerfab == null)
                {
                    //加载技能预制体
                    skill.skillPerfab = LoadPrefab("SkillPerfab", skill.skillPerfabName);
                }
                if(!string.IsNullOrEmpty(skill.skillHitFxName)&&skill.skillHitFxPerfab==null)
                {
                    //加载技能受击点预制体
                    skill.skillHitFxPerfab = LoadPrefab("SkillHitPerfab", skill.skillHitFxName);
                }
                //把技能放到对象池中
                ObjectPool.Instance.Add(skill.skillPerfabName, skill.skillPerfab);
                ObjectPool.Instance.Add(skill.skillHitFxName, skill.skillHitFxPerfab);
                //确定技能的拥有者
                skill.skillOnwer = this.gameObject;
            }
        }
        /// <summary>
        /// 加载技能预制件（通过配置文件）
        /// </summary>
        /// <returns>The prefab.</returns>
        /// <param name="path">路径</param>
        /// <param name="resName">技能名称</param>
        public GameObject LoadPrefab(string path, string resName)
        {
            return Resources.Load(path + "/" + resName) as GameObject;
        }
        /// <summary>
        /// 通过技能ID查找返回该可用的技能
        /// </summary>
        /// <returns>The skill.</returns>
        /// <param name="id">技能ID</param>
        public SkillData PrepareSkill(int id)
        {
            var skillData = skills.Find(p => p.skillID == id);
            if (skillData != null)
            {
                if (skillData.skillCoolRemain <= 0 && skillData.skillCostSP
                  <= skillData.skillOnwer.GetComponent<PlayerState>().HP)
                {
                    return skillData;
                }
            }
            return null;
        }
        /// <summary>
        /// 释放技能
        /// </summary>
        /// <param name="skillData">Skill data.</param>
        public void DeploySkill(SkillData skillData)
        {
            //用对象池存放技能预制件
            Transform tempSkill = TransformHelper.FindChild(transform, "SkillPloyerPoint");
            print(skillData.skillPerfabName);
            print(skillData.skillPerfab);
            print(tempSkill.position);
            GameObject skillPerfabClone = ObjectPool.Instance.CreateObject(
                skillData.skillPerfabName, skillData.skillPerfab, tempSkill.position, transform.rotation);
            //设置技能的父物体
            skillPerfabClone.transform.SetParent(tempSkill);
            //调用该技能身上的技能释放器进行技能释放（MeleeSkillDeployer）
            var deployer = skillPerfabClone.GetComponent<MeleeSkillDeployer>();
            ////////////////////////////////////////////////////////////////////////最终执行
            //告诉技能释放器当前要释放的技能
            deployer.skillDataDeal = skillData;
            //执行技能的所有方法（带有回收方法）
            deployer.DeploySkill();
            //开启冷却
            StartCoroutine(CoolTimeDown(skillData));
            //用对象池回收技能
            ObjectPool.Instance.CollectObject(skillPerfabClone, skillData.skillDurationTime);
        }
        private IEnumerator CoolTimeDown(SkillData skilldData)
        {
            skilldData.skillCoolRemain = skilldData.skillCoolTime;
            //每过1S  剩余冷却时间-1S
            while(skilldData.skillCoolRemain>0)
            {
                yield return new WaitForSeconds(1);
                skilldData.skillCoolRemain -= 1;
            }
            //纠正
            skilldData.skillCoolRemain = 0;
        }
        /// <summary>
        /// 获取所有可以释放的技能
        /// </summary>
        /// <returns>The useable skills.</returns>
        public List<SkillData> GetUseableSkills()
        {
            return skills.FindAll(p => p.skillCoolRemain <= 0 
                                  && p.skillCostSP < p.skillOnwer.GetComponent<PlayerState>().SP);
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
    }
}
