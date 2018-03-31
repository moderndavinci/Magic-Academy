using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Tools;

namespace Character.Skill
{
    /// <summary>
    /// 圆形攻击选择器（待优化）
    /// </summary>
    public class CircleAttackSelector : IAttackSelector
    {
        public GameObject[] SelectTarget(SkillData skillData, Transform trans)
        {
            //1.从技能拥有者的位置(这个位置可以改) 发射一个圆形射线，半径为技能的攻击距离,去检测到所有在攻击半径内的碰撞体
            Collider[] colliders = Physics.OverlapSphere(trans.position, skillData.skillAttackDistance);
            //2.从所有colliders中筛选我们需要的目标物体
            //筛选条件：1.活着的，2.物体标签与技能所攻击的标签相同
            Collider[] array = Array.FindAll(colliders,
                                          p => Array.IndexOf(skillData.skillAttackTargetTags, p.tag) >= 0
                                           && p.GetComponent<EnemyState>().HP > 0);
            if (array.Length == 0 || array == null) return null;
            switch (skillData.skillAttackType)
            {
                //如果是单体攻击，返回最近的目标物体
                case SkillAttackType.Single:
                    return new GameObject[] { ArrayHelper.Min(array, p => Vector3.Distance(p.transform.position, trans.position)).gameObject };
                case SkillAttackType.Group:
                    return ArrayHelper.Select(array, p => p.gameObject);
            }
            return null;
        }
    }
}
