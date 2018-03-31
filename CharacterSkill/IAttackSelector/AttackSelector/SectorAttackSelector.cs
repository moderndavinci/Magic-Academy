using System.Collections;
using System.Collections.Generic;
using System;
using Tools;
using UnityEngine;

namespace Character.Skill
{
    /// <summary>
    /// 扇形攻击方式（范围）
    /// </summary>
    public class SectorAttackSelector : IAttackSelector
    {
        public GameObject[] SelectTarget(SkillData skillData, Transform trans)
        {
            //1.从技能拥有者的位置(这个位置可以改)发射一个圆形射线，半径为技能的
            //攻击距离，去检测到所有在攻击半径的碰撞体
            Collider[] colliders = Physics.OverlapSphere(trans.position, skillData.skillAttackDistance);
            //2.从所有colliders中筛选我们需要的目标物体
            //条件：1.活着的 2.标签和技能所攻击的标签是相同的
            Collider[] array = Array.FindAll(colliders,
                                           p => Array.IndexOf(skillData.skillAttackTargetTags, p.tag) >= 0
                                           && p.GetComponent<EnemyState>().HP > 0
                                           && Vector3.Angle(trans.forward, p.transform.position - trans.position) < skillData.skillAttackAngle);
            if (array.Length == 0 || array == null) return null;
            Debug.Log(array.Length);
            switch (skillData.skillAttackType)
            {
                //如果是单体的，返回最近的目标物体
                case SkillAttackType.Single:
                    return new GameObject[]{
                        ArrayHelper.Min(array,p=>Vector3.Distance(p.transform.position,trans.position)).gameObject
                    };
                //如果是群体，返回所有的目标物体
                case SkillAttackType.Group:
                    return ArrayHelper.Select(array, p => p.gameObject);

            }
            return null;
        }
    }
}
