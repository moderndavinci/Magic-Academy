using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Character.Skill
{
    /// <summary>
    /// 技能配置类/工厂类：进行技能的加工
    /// </summary>
    public class DeployerConfigFactory
    {
        //1.技能攻击模式  2.对于自身影响   3.对于敌方的影响
        public static IAttackSelector CreateAttackSelector(SkillData skillData)
        {
            IAttackSelector attackSelector = null;
            //1.通过反射得到相应的类型
            string pathAll = "Character.Skill." + skillData.skillDamageMode + "AttackSelector";
            Type type = Type.GetType(pathAll);
            //2.动态创建对象
            attackSelector = Activator.CreateInstance(type) as IAttackSelector;
            return attackSelector;
        }
        /// <summary>
        /// 初始化技能对自身的影响
        /// </summary>
        public static List<ISelfImpact> CreateSelfImpact(SkillData skillData)
        {
            List<ISelfImpact> list = new List<ISelfImpact>();
            //list.Add(new );
            //.........添加对玩家的影响类型
            list.Add(new CostSPSelfImpact());
            return list;
        }
        public static List<ITargetImpact> CreateTargetImpact(SkillData skillData)
        {
            List<ITargetImpact> list = new List<ITargetImpact>();
            //list.Add();
            //........添加对目标的影响类型
            list.Add(new DamageTargetImpact());
            return list;
        }
       
    }
}
