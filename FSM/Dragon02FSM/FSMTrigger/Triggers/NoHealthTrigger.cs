using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon02.FSM
{
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            return fsm.chState.HP <= 0;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.NoHealth;
        }
    }
}
