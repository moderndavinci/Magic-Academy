using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 执行释放技能的方法
    /// </summary>
    public class MeleeSkillDeployer : SkillDeployer
    {
        public override void DeploySkill()
        {
            //如果当前技能为空返回
            if (skillDataDeal == null) return;
            //从新选择目标
            skillDataDeal.skillTargets = ResetTargets();
            //执行技能对自身的影响
            listSelfImpact.ForEach(p=>p.SelfImpact(this,skillDataDeal,skillDataDeal.skillOnwer));
            //执行技能对目标的影响
            listTargetImpact.ForEach(p=>p.TargetImpact(this,skillDataDeal,null));
        }
    }
}
