using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using System;

namespace Dragon02.FSM
{
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public class PatrolingState : FSMState
    {
        System.Random rand = new System.Random();
        public override void Action(BaseFSM fsm)
        {
            //物体当前位置与路点的位置的距离相遇亭子距离时
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[fsm.currentWP])
                < fsm.stopDistance) 
            {
                //随机寻路
                fsm.currentWP = rand.Next(0,fsm.wayLenght);
            }
            fsm.PlayAnim(AnimatorName.run);
            fsm.agent.SetDestination(fsm.wayPoints[fsm.currentWP]);
        }

        protected override void Init()
        {
            stateID = FSMStateID.Patroling;
        }
    }
}
