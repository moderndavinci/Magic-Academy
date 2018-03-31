using System.Collections;
using System.Collections.Generic;
using Tools;
using Character;
using UnityEngine;

namespace Dragon.FSM
{
    /// <summary>
    /// 回到移动点进行回血回蓝
    /// </summary>
    public class BackBloodState : FSMState
    {
        bool isBackBlood;
        public override void Action(BaseFSM fsm)
        {
            //物体当前位置与路点的位置的距离相遇亭子距离时
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[0])
                < fsm.stopDistance)
            {
                //加血
                fsm.chState.HP+= 4;
            }
            Debug.Log("回血状态");
            fsm.PlayAnim(AnimatorName.idle);
            TransformHelper.Rotation(fsm.transform, fsm.wayPoints[0], fsm.chState.rotationSpeed);

            fsm.transform.position = Vector3.Lerp(fsm.transform.position, fsm.wayPoints[0], fsm.chState.moveSpeed);
        }

        protected override void Init()
        {
            //throw new System.NotImplementedException();
            stateID = FSMStateID.BackBlood;
        }
    }
}
