using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 对自身造成的影响
    /// </summary>
    public interface ISelfImpact
    {
        /// <summary>
        /// 自身影响
        /// </summary>
        /// <param name="deployer">释放器</param>
        /// <param name="skillData">当前技能</param>
        /// <param name="go">Go.</param>
        void SelfImpact(SkillDeployer deployer, SkillData skillData, GameObject go);
    }
}
