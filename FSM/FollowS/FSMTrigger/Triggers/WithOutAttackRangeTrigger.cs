using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Follow.FSM
{
    public class WithOutAttackRangeTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target != null)
            {
                return Vector3.Distance(fsm.transform.position, fsm.target.position)
                              > fsm.chState.attackRange;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.WithOutAttackRange;
        }
    }
}
