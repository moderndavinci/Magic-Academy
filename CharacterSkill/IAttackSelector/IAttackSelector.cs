using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 选着攻击器（范围） 算法 ：选择什么范围里的敌人作为目标
    /// </summary>
    public interface IAttackSelector 
    {
        /// <summary>
        /// 根据技能 选着攻击目标
        /// </summary>
        /// <returns>The target.</returns>
        /// <param name="skillData">某个技能</param>
        /// <param name="trans">技能拥有者的位置（玩家和敌人）</param>
        GameObject[] SelectTarget(SkillData skillData, Transform trans);
    }
}
