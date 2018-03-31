using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Dragon02.FSM
{
    /// <summary>
    /// 死亡状态
    /// </summary>
    public class DeadState : FSMState
    {
        bool isDead = false;
        public override void Action(BaseFSM fsm)
        {
            if (isDead) return;
            if (!isDead)
            {
                fsm.chState.Death();
                fsm.DestoryObj(fsm.gameObject, 4);
                isDead = true;
            }
        }

        protected override void Init()
        {
            stateID = FSMStateID.Dead;
        }
    }
}
