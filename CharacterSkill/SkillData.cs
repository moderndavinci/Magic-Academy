using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 技能数据类（基础数据）
    /// </summary>
    public class SkillData
    {
        /// <summary>
        /// 技能ID
        /// </summary>
        public int skillID;
        /// <summary>
        /// 技能名称
        /// </summary>
        public string skillName;
        /// <summary>
        /// 技能描述
        /// </summary>
        public string skillDescription;
        /// <summary>
        /// 技能冷却时间
        /// </summary>
        public int skillCoolTime;
        /// <summary>
        /// 技能冷却时间剩余
        /// </summary>
        public int skillCoolRemain;
        /// <summary>
        /// 技能蓝量的消耗
        /// </summary>
        public int skillCostSP;
        /// <summary>
        /// 技能的攻击距离
        /// </summary>
        public int skillAttackDistance;
        /// <summary>
        /// 技能攻击角度
        /// </summary>
        public int skillAttackAngle;
        /// <summary>
        /// 技能攻击目标Tag
        /// </summary>
        public string[] skillAttackTargetTags = { "EnemySoldier", "Boss" };
        /// <summary>
        /// (在攻击范围内)攻击目标对象数组
        /// </summary>
        public GameObject[] skillTargets;
        /// <summary>
        /// 连击的下一个技能编号
        /// </summary>
        public int skillNextBatterId;
        /// <summary>
        /// 技能的伤害比率
        /// </summary>
        public int skillDamage;
        /// <summary>
        /// 技能持续时间
        /// </summary>
        public int skillDurationTime;
        /// <summary>
        /// 技能伤害间隔
        /// </summary>
        public int skillDamageInterval;
        /// <summary>
        /// 技能拥有者（用于对拥有者的影响(减去SP)）
        /// </summary>
        public GameObject skillOnwer;
        /// <summary>
        /// 技能预制件的名称
        /// </summary>
        public string skillPerfabName;
        /// <summary>
        /// 技能预制件
        /// </summary>
        public GameObject skillPerfab;
        /// <summary>
        /// 技能动画(使用技能时的动画)
        /// </summary>
        public string skillAnimationName;
        /// <summary>
        /// 技能受击特效名称
        /// </summary>
        public string skillHitFxName;
        /// <summary>
        /// 技能受击特效预制体
        /// </summary>
        public GameObject skillHitFxPerfab;
        /// <summary>
        /// 技能的等级
        /// </summary>
        public int skillLevel;
        /// <summary>
        /// 技能是否激活
        /// </summary>
        public bool skillActivated;
        /// <summary>
        /// 技能伤害类型（群体、单体）
        /// </summary>
        public SkillAttackType skillAttackType;
        /// <summary>
        /// 技能伤害模式（范围形状）
        /// </summary>
        public SkillDamageMode skillDamageMode;
    }
    public enum SkillAttackType
    {
        Single,//单体
        Group,//群体
    }
    public enum SkillDamageMode
    {
        Circle,//圆形
        Sector,//扇形
        Rectangle,//方形
    }

}
