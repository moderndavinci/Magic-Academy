using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragon02.FSM
{
    /// <summary>
    /// 玩家进入攻击范围
    /// </summary>
    public class ReachPlayerTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target!=null)
            {
                Debug.Log("攻击触发");
                return Vector3.Distance(fsm.transform.position, fsm.target.position) 
                              < fsm.chState.attackRange;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.ReachPlayer;
        }
    }
}
