using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    public class PatrolingTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.Patroling;
        }
    }
}
