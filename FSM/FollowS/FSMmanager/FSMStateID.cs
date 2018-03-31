using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Follow.FSM
{
    public enum FSMStateID
    {
        /// <summary>
        /// 巡逻状态
        /// </summary>
        Patroling,
        /// <summary>
        /// 追逐状态
        /// </summary>
        Pursue,
        /// <summary>
        /// 攻击状态
        /// </summary>
        Attack,
        /// <summary>
        /// 闲置状态
        /// </summary>
        Idle,
        /// <summary>
        /// 死亡状态
        /// </summary>
        Dead,
        /// <summary>
        /// 默认状态
        /// </summary>
        Default,
        /// <summary>
        /// 无状态
        /// </summary>
        None
    }
}
