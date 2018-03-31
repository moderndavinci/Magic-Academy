using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 对于目标造的影响
    /// </summary>
    public interface ITargetImpact
    {
        void TargetImpact(SkillDeployer deployer, SkillData skillData, GameObject go);

    }
}
