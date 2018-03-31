using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Follow.FSM
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
                fsm.agent.SetDestination(fsm.target.position);
            }
        }

        protected override void Init()
        {
            stateID = FSMStateID.Pursue;
        }
        public override void ExitState(BaseFSM fsm)
        {
            fsm.StopPursue();
        }
    }
}
