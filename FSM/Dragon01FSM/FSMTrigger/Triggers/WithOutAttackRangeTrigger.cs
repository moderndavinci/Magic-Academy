using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
public class WithOutAttackRangeTrigger : FSMTrigger {
        
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target != null)
            {
                if(Vector3.Distance(fsm.transform.position, fsm.target.position)
                   > fsm.chState.attackRange)
                {
                    return true;
                }
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.WithOutAttackRange;
        }
	
    }
}
