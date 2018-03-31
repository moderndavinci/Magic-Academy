using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Character;

namespace Dragon.FSM
{
    /// <summary>
    /// 攻击状态
    /// </summary>
    public class AttackState : FSMState
    {
        float timer;

        protected override void Init()
        {
            stateID = FSMStateID.Attack;
        }

        public override void Action(BaseFSM fsm)
        {
            timer += Time.deltaTime;
            if (fsm.target!=null)
            {
                //朝向目标
                //fsm.transform.LookAt(fsm.target.transform.position);
                TransformHelper.Rotation(fsm.transform, fsm.target.position, fsm.chState.rotationSpeed);
                if (timer > fsm.chState.attackInv && fsm.target.GetComponent<PlayerState>().HP > 0)
                {
                    fsm.PlayAnim(AnimatorName.attack01);
                    //调用目标受伤方法
                    fsm.target.GetComponent<PlayerState>().OnDamage(fsm.chState.attack);
                }
            }
        }
        public override void EnterState(BaseFSM fsm)
        {
            Debug.Log("进入攻击状态");
        }
    }
}
