using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if(fsm.chState.HP <= 0)
            {
                return true;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.NoHealth;
        }
    }
}
