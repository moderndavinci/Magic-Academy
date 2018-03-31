using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Character.Skill
{
    /// <summary>
    /// 对目标造成伤害的方法
    /// </summary>
    public class DamageTargetImpact : ITargetImpact
    {
        int baseDamage;//基础伤害
        public void TargetImpact(SkillDeployer deployer, SkillData skillData, GameObject go)
        {
            if(skillData.skillOnwer!=null&&skillData.skillOnwer.gameObject!=null)
            {
                baseDamage = skillData.skillOnwer.GetComponent<PlayerState>().attack;
            }
            deployer.StartCoroutine(RepeatDamage(deployer,skillData));
        }
        /// <summary>
        /// 一次伤害
        /// </summary>
        /// <param name="skillData">当前技能</param>
        /// <param name="targetObj">目标物体</param>
        private void OnceDamage(SkillData skillData,GameObject targetObj)
        {
            int damageVal = baseDamage * skillData.skillDamage;
            var chState = targetObj.GetComponent<EnemyState>();
            chState.OnDamage(damageVal);
            Debug.Log(skillData.skillHitFxPerfab);
            if(skillData.skillHitFxPerfab!=null&&chState.hitPos!=null)
            {
                //1>创建受击点特效的预制体（属于技能的预制,创建在角色受击点的位置）
                GameObject go = ObjectPool.Instance.CreateObject(skillData.skillHitFxName,
                                                              skillData.skillHitFxPerfab,
                                                              chState.hitPos.position,
                                                               new Quaternion(0, 0, 0, 0));
                //2>目标受击点预制体的回收
                ObjectPool.Instance.CollectObject(go,skillData.skillDurationTime);
            }
        }
        /// <summary>
        /// 重复伤害
        /// </summary>
        /// <returns>The damage.</returns>
        /// <param name="deployer">技能释放器</param>
        /// <param name="skillData">当前技能</param>
        public IEnumerator RepeatDamage(SkillDeployer deployer,SkillData skillData)
        {
            int attackTime = 0;
            skillData.skillTargets = deployer.ResetTargets();

            do
            {
                //保护程序
                if (skillData.skillTargets != null && skillData.skillTargets.Length > 0)
                {
                    //对当前所有目标进行一次伤害
                    for (int i = 0; i < skillData.skillTargets.Length; i++)
                    {
                        OnceDamage(skillData, skillData.skillTargets[i]);
                    }
                }
                yield return new WaitForSeconds(skillData.skillDamageInterval);
                attackTime += skillData.skillDamageInterval;
                Debug.Log(skillData.skillDurationTime);
                Debug.Log("对目标多次伤害");
            }
            while (attackTime > skillData.skillDurationTime);//直到攻击计时器大于技能的持续时间
        }
    }
}
