using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon.FSM
{
    /// <summary>
    /// 血量过低
    /// </summary>
    public class LessHealthTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            //throw new System.NotImplementedException();
            if(fsm.chState.HP<=fsm.lessHP)
            {
                return true;
            }
            return false;
        }

        protected override void Init()
        {
            //throw new System.NotImplementedException();
            triggerID = FSMTriggerID.LessHealth;
        }
    }
}
