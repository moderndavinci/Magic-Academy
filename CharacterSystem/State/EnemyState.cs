using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

namespace Character
{
    /// <summary>
    /// 目标的状态
    /// </summary>
    public class EnemyState : CharacterState
    {
        bool isDeath = false;
        public void Start()
        {
            base.Start();
        }
        //重写死亡方法
        public override void Death()
        {
            
            if (isDeath) return;
            if (!isDeath)
            {
                anim.PlayAnim(AnimatorName.dead);
                isDeath = true;
            }
            //对象池回收
            ObjectPool.Instance.CollectObject(gameObject,4);
        }

    }
}
