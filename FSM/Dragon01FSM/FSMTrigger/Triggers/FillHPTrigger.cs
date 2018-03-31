using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    public class FillHPTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if(fsm.chState.HP>=500)
            {
                return true;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.FillHP;
        }
    }
}
