using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Character
{
    /// <summary>
    /// 角色当前状态和相关属性
    /// </summary>
    public class CharacterState : MonoBehaviour
    {
        /// <summary>
        /// 血量
        /// </summary>
        public int HP;
        /// <summary>
        /// 蓝量
        /// </summary>
        /// 飞行器没有蓝量
        public int SP;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float moveSpeed;
        /// <summary>
        /// 旋转速度
        /// </summary>
        public float rotationSpeed;
        /// <summary>
        /// 经验值
        /// </summary>
        public int exp;
        /// <summary>
        /// 防御力
        /// </summary>
        public int defense;
        /// <summary>
        /// 攻击力
        /// </summary>
        public int attack;
        /// <summary>
        /// 攻击间隔
        /// </summary>
        public int attackInv;
        /// <summary>
        /// 攻击范围
        /// </summary>
        public float attackRange;
        /// <summary>
        /// 攻击视野
        /// </summary>
        public float targetRange;
        [HideInInspector]
        public CharacterAnimator anim;
        [HideInInspector]
        public CharacterMotor motor;
        [HideInInspector]
        public Transform hitPos;

        public virtual void OnDamage(int damageValue)
        {
            //减去防御力是其受到的真实伤害
            int damageVal = damageValue - defense;
            HP = HP - damageVal;
            //HP大于0 执行相关方法
            if(HP>0){}
            //HP小于0 死亡
            if (HP <= 0) Death();
        }
        //需要子类来实现相关的死亡方法
        public virtual void Death()
        {
            //对象池回收
            ObjectPool.Instance.CollectObject(gameObject);
        }

        public void Start()
        {
            //找到受伤点名为“HitPoint”
            hitPos = TransformHelper.FindChild(transform, "HitPoint");
            //飞行器不需要动画
            anim = GetComponent<CharacterAnimator>();
            //motor = GetComponent<CharacterMotor>();
        }

    }
}
