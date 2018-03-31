using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using System;

namespace Follow.FSM
{
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public class PatrolingState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {
            //物体当前位置与路点的位置的距离相遇亭子距离时
            if (Vector3.Distance(fsm.transform.position, fsm.PlayerPos.position)
                < fsm.stopDistance) 
            {
                Debug.Log("停止移动");
                fsm.PlayAnim(AnimatorName.idle);
                fsm.StopPursue();
                return;
            }
            fsm.PlayAnim(AnimatorName.run);
            fsm.agent.SetDestination(fsm.PlayerPos.position);
        }

        protected override void Init()
        {
            stateID = FSMStateID.Patroling;
        }
    }
}
