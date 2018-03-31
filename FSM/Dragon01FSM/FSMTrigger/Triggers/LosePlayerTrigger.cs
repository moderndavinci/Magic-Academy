using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Dragon.FSM
{
    /// <summary>
    /// 丢失玩家
    /// </summary>
    public class LosePlayerTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target!=null)
            {
                return Vector3.Distance(fsm.transform.position, fsm.target.position) 
                              > fsm.chState.targetRange;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.LosePlayer;
        }
    }
}
