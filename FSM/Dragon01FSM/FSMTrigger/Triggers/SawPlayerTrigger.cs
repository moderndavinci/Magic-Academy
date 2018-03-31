using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Dragon.FSM
{
    /// <summary>
    /// 发现玩家
    /// </summary>
    public class SawPlayerTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target!=null&&fsm.target.tag=="Player")
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
