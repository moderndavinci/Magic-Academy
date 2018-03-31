using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Tools;
using Character.Skill;

namespace Character
{
    /// <summary>
    /// 技能系统控制中枢（外观设计模式）
    /// </summary>
    public class CharacterSkillSystem : MonoBehaviour
    {
        /// <summary>
        /// 动画组件
        /// </summary>
        private CharacterAnimator anim;
        /// <summary>
        /// 技能管理系统
        /// </summary>
        private CharacterSkillManager manager;
        /// <summary>
        /// 当前使用的技能
        /// </summary>
        private SkillData currentSkillData = null;
        /// <summary>
        /// 当前攻击的目标
        /// </summary>
        private GameObject currentAttackTarget = null;
        private CharacterEventAttack animEvent;

        private void Start()
        {
            anim = GetComponent<CharacterAnimator>();
            manager = GetComponent<CharacterSkillManager>();
            animEvent = GetComponentInChildren<CharacterEventAttack>();
            //绑定技能执行程序
            animEvent.attackhandler += AnimEvent_attackHandler;
        }
        /// <summary>
        /// 通过动画中的事件绑定执行相关方法
        /// </summary>
        private void AnimEvent_attackHandler()
        {
            if(currentSkillData!=null)
            {
                //技能释放
                manager.DeploySkill(currentSkillData);
            }
        }
        /// <summary>
        /// 使用技能进行攻击（在输入控制类中进行使用）
        /// </summary>
        /// <param name="skillID">技能ID</param>
        /// <param name="isBatter">是否连击<c>true</c> is batter.</param>
        public void AttackUseSkill(int skillID,bool isBatter)
        {
            if (anim.defultName == AnimatorName.idle)
            {
                //1.联机操作
                //2.当前技能进入准备状态
                currentSkillData = manager.PrepareSkill(skillID);
                //3.找到受击目标（这个只是进行攻击效果的更改，其他不做任何处理）
                GameObject selectedTarget = SelectTarget();

                if (selectedTarget != null)
                {
                    //4.面向攻击目标
                    //transform.LookAt(selectedTarget.transform);
                    //5.将之前的选中效果隐藏
                    currentAttackTarget = selectedTarget;
                    //6.将现在的选中（攻击效果） 显示
                }
                //播放当前技能的攻击动画（将执行绑定在了动画事件中）执行技能
                anim.PlayAnim(currentSkillData.skillAnimationName);
            }
        }
        /// <summary>
        /// 测试搜索目标
        /// </summary>
        /// <returns>The target.</returns>
        private GameObject SelectTarget()
        {
            //使用距离计算 （优化）
            Collider[] colliders = Physics.OverlapSphere(transform.position,
                                                       currentSkillData.skillAttackDistance);
            if (colliders.Length == 0 || colliders == null) return null;
            Collider[] array = Array.FindAll(colliders, p =>
                                             (Array.IndexOf(currentSkillData.skillAttackTargetTags, p.tag) >= 0)
                                              && p.GetComponent<EnemyState>().HP > 0);
            if (array.Length == 0 || array == null) return null;
            GameObject go = ArrayHelper.Min(array, p => Vector3.Distance(transform.position, p.transform.position)).gameObject;
            return go;
        }
    }
}
