using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 释放技能对自身蓝量的影响
    /// </summary>
    public class CostSPSelfImpact : ISelfImpact
    {
        public  void SelfImpact(SkillDeployer deployer, SkillData skillData, GameObject go)
        {
            if (skillData.skillOnwer == null) return;
            PlayerState chstate = skillData.skillOnwer.GetComponent<PlayerState>();
            chstate.SP -= skillData.skillCostSP;
        }

    }
}
