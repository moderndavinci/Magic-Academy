using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using System;
using Character;

namespace Dragon.FSM
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
                fsm.currentWP = rand.Next(0, fsm.wayPointLeng);
                //rotationTemp=Quaternion.
            }
            fsm.PlayAnim(AnimatorName.run);
            TransformHelper.Rotation(fsm.transform,fsm.wayPoints[fsm.currentWP],fsm.chState.rotationSpeed);
            //fsm.transform.rotation=Quaternion.Lerp(fsm.transform.rotation,)
            //fsm.transform.LookAt(fsm.wayPoints[fsm.currentWP]);
            fsm.transform.position = Vector3.Lerp(fsm.transform.position, fsm.wayPoints[fsm.currentWP], fsm.chState.moveSpeed);
        }

        protected override void Init()
        {
            stateID = FSMStateID.Patroling;
        }
    }
}
