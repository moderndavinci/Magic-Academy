using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    public enum FSMTriggerID
    {
        /// <summary>
        /// 开始巡逻
        /// </summary>
        Patroling,
        /// <summary>
        /// 发现玩家
        /// </summary>
        SawPlayer,
        /// <summary>
        /// 玩家进入攻击范围
        /// </summary>
        ReachPlayer,
        /// <summary>
        /// 玩家超出攻击范围
        /// </summary>
        WithOutAttackRange,
        /// <summary>
        /// 丢失玩家
        /// </summary>
        LosePlayer,
        /// <summary>
        /// 击杀玩家
        /// </summary>
        KilledPlayer,
        /// <summary>
        /// 血量过低
        /// </summary>
        LessHealth,
        /// <summary>
        /// 满血状态
        /// </summary>
        FillHP,
        /// <summary>
        /// 没有血量
        /// </summary>
        NoHealth
    }
}
