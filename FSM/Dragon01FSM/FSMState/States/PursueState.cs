using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Character;

namespace Dragon.FSM
{
    /// <summary>
    /// 追逐状态
    /// </summary>
    public class PursueState : FSMState
    {
        public override void Action(BaseFSM fsm)
        {
            if (fsm.target!=null)
            {
                fsm.PlayAnim(AnimatorName.run);
                //fsm.agent.SetDestination(fsm.target.position);
                TransformHelper.Rotation(fsm.transform, fsm.target.position, fsm.chState.rotationSpeed);
                fsm.transform.position= Vector3.Lerp(fsm.transform.position, fsm.target.position, fsm.chState.moveSpeed);
            }
        }

        protected override void Init()
        {
            stateID = FSMStateID.Pursue;
        }
    }
}
