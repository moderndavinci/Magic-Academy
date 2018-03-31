using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Follow.FSM
{
    /// <summary>
    /// 发现玩家
    /// </summary>
    public class SawPlayerTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target!=null)
            {
                return Vector3.Distance(fsm.transform.position, fsm.target.position) 
                              < fsm.chState.targetRange;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.SawPlayer;
        }
    }
}
