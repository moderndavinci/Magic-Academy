using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 技能释放器
    /// </summary>
    public abstract class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        /// <summary>
        /// 给有效技能添加如下几种功能
        /// 1.绑定技能的攻击方式  技能的攻击类型  技能的伤害类型
        /// 2.重置目标
        /// 3.为skillData绑定对与自身影响  及目标影响的方法
        /// </summary>
        /// <value>The skill data deal.</value>
        public SkillData skillDataDeal
        {
            get{
                return skillData;
            }
            set
            {
                if (value == null) return;
                if (skillData == null //技能为空
                  || value.skillID != skillData.skillID //当前技能与给定的技能ID不同
                  || value.skillID == skillData.skillID && value.skillLevel != skillData.skillLevel)
                {
                    skillData = value;
                    attackSelector = DeployerConfigFactory.CreateAttackSelector(skillData);
                    listSelfImpact = DeployerConfigFactory.CreateSelfImpact(skillData);
                    listTargetImpact = DeployerConfigFactory.CreateTargetImpact(skillData);
                }
            }
        }
        //攻击选择器： 确定目标选择算法：圆形  扇形 矩形
        protected IAttackSelector attackSelector;
        //技能对自身的影响
        protected List<ISelfImpact> listSelfImpact = new List<ISelfImpact>();
        //技能对目标的影响
        protected List<ITargetImpact> listTargetImpact = new List<ITargetImpact>();

        /// <summary>
        /// 释放技能，执行技能对自身和目标的影响
        /// </summary>
        public abstract void DeploySkill();

        /// <summary>
        /// 选择技能释放范围的目标
        /// </summary>
        /// <returns>The targets.</returns>
        public GameObject[] ResetTargets()
        {
            GameObject[] targetObjs = attackSelector.SelectTarget(skillData, transform);
            return targetObjs;
        }
    }
}
