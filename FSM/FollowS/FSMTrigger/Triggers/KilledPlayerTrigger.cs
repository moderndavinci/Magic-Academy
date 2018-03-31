﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Follow.FSM
{
    /// <summary>
    /// 玩家被终结
    /// </summary>
    public class KilledPlayerTrigger : FSMTrigger
    {
        public override bool IsTrigger(BaseFSM fsm)
        {
            if (fsm.target != null)
            {
                if (fsm.target.GetComponent<CharacterState>().HP <= 0)
                {
                    fsm.target.GetComponent<CharacterState>().Death();
                    return true;
                }
            }
            if(fsm.target == null)
            {
                return true;
            }
            return false;
        }

        protected override void Init()
        {
            triggerID = FSMTriggerID.KilledPlayer;
        }
    }
}
